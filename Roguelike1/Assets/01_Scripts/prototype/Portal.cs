using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Debug.Log("je hebt gewonnen");
            // nu zou de win scene geladen moeten worden.
        }
    }

}
