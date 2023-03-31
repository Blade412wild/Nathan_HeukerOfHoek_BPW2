using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Item : MonoBehaviour
{
    public RawImage uiImage { get; private set; }
    public Item itemReference { get; private set; }
    public UI_ItemSlot currentSlot { get; private set; }

    private void Awake()
    {
        uiImage = GetComponent<RawImage>();
    }

    public void Setup(Item item)
    {
        itemReference = item;
        itemReference.gameObject.SetActive(false);
        itemReference.OnUseEvent += OnUseItem;
        uiImage.texture = item.icon;
    }

    public void DropItem(Vector3 dropPosition)
    {
        itemReference.gameObject.SetActive(true);
        itemReference.gameObject.transform.position = dropPosition; 
        currentSlot.ReleaseItem();
        currentSlot = null;
    }

    public void SetSlot(UI_ItemSlot slot)
    {
        currentSlot = slot;
    }

    private void OnUseItem(Item usedItem)
    {
        if (usedItem.isConsumable)
        {
            currentSlot.ReleaseItem();
            Destroy(gameObject);
        }
    }

    public void Use()
    {
        Debug.Log("Used HealthPosition");
        itemReference.Use();
    }

}
