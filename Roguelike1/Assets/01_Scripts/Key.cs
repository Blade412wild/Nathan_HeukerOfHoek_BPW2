using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameEvent PickedUpKey;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            PickedUpKey?.Invoke();
            Destroy(gameObject);
        }   
    }

}
