using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public UI_Item UI_ItemPrefab;
    public List<UI_ItemSlot> slots = new List<UI_ItemSlot>();

    public Item testItemPrefab;
    [SerializeField] private float pickupRadius = 3f;

    private PlayerInputAction playerInputActions;
    private Camera camera;


    private void Start()
    {
        camera = Camera.main;
        GetComponentsInChildren<UI_ItemSlot>(slots);
        playerInputActions = new PlayerInputAction();
        playerInputActions.FreeRoam.Enable();
        playerInputActions.FreeRoam.ItemPickUp.performed += ctx => { TryToPickItem(); };
    }

    public void PickupItem(Item item)
    {
        var emptySlot = slots.Find(x => x.item == null);
        if(emptySlot != null)
        {
            UI_Item obj = Instantiate(UI_ItemPrefab);
            obj.Setup(item);
            emptySlot.ObtainItem(obj);
        }
        else
        {
            Debug.Log("Inventory is Full!");
        }
    }

    //private void Update()
    //{
    //    //for testing, pickup an item
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        var pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
    //        Ray r = Camera.main.ScreenPointToRay(pos);
    //        if(Physics.Raycast(r, out RaycastHit hitinfo))
    //        {
    //            Item item = hitinfo.collider.GetComponent<Item>();
    //            if (item != null)
    //            {
    //                PickupItem(item);
    //            }
    //        }
    //    }
    //}
    public void TryToPickItem()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Item item = hitInfo.collider.GetComponent<Item>();
            if (item != null)
            {
                PickupItem(item);
            }
        }
    }
}
