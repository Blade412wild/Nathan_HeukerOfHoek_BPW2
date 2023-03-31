using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine.InputSystem;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private PlayerInputAction playerInput;
    private Vector3Int currentPosition;
    private int speed = 1;
  


    // Start is called before the first frame update
    void Start()
    {

        playerInput = new PlayerInputAction();
        playerInput.FreeRoam.Test.performed += ctx => { Movement(); };

        currentPosition = Vector3Int.RoundToInt(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition.x = Mathf.RoundToInt(transform.position.x);
        
    }

    private void Movement()
    {
        Debug.Log("move");
        transform.position = new Vector3Int(currentPosition.x + speed, 0, 0);
    }
}
