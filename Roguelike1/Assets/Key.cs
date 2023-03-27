using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private GameEvent KeyIsPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            KeyIsPickedUp?.Invoke();

            Destroy(gameObject);
        }
    }

}
