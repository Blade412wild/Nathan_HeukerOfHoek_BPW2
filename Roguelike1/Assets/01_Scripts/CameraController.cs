using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player player1;
    private Vector3 gizmoPos;
    public float SmoothSpeed = 0.2f;
    public Vector3 Offset;


    // Start is called before the first frame update
    public void SearchPlayer()
    {
        player1 = FindAnyObjectByType<Player>();
        Debug.Log(player1.gameObject.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player1 != null)
        {
            Vector3 desiredPosition = player1.transform.position + Offset;
            Vector3 SmoothPostion = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
            transform.position = SmoothPostion;

        }

    }



}