using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool KeyPickedUp;
    private void OnTriggerEnter(Collider other)
    {
        
        // en speler heeft de key;
        if (other.gameObject.GetComponent<Player>() && KeyPickedUp == true)
        {
            Debug.Log("je hebt gewonnen");
            // nu zou de win scene geladen moeten worden.
        }
    }

    public void KeyIsPickUp()
    {
        KeyPickedUp = true;
    }

}
