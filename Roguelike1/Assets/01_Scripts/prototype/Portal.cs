using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    private bool PickedUpKey;
    private void OnTriggerEnter(Collider other)
    {
        
        // en speler heeft de key;
        if (other.gameObject.GetComponent<Player>() && PickedUpKey == true)
        {
            Debug.Log("je hebt gewonnen");
            // nu zou de win scene geladen moeten worden.
        }
    }

    public void PickedUpKeyEvent()
    {
        PickedUpKey = true;
    }

}
