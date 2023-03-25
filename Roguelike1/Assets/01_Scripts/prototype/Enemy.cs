using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Range;
    public int RayDistance;

    private PlayerMovement playerMovement;
    private Player player;
    private bool visible;






    private void OnEnable()
    {
        player = FindAnyObjectByType<Player>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }


    //Checked of de Speler in de Buurt is van de Enemy
    public void CheckIfPlayerIsInRange()
    {
        Vector3Int playerCurrentLocation = playerMovement.currentLocation;
        PlayerDistance(playerCurrentLocation);

        

    }


    //Wanneer het de turn is van de Enemy
    private void PathCalculation()
    {

    }

    private void PlayerDistance(Vector3Int playerCurrentLocation)
    {
        Vector3Int enemyLocation = Vector3Int.CeilToInt(transform.position);
        if (Vector3Int.Distance(playerCurrentLocation, enemyLocation) < Range)
        {
            Debug.Log("In Range");
            //visible = isPlayerVisible(playerCurrentLocation);
        }
    }

    /*
    private bool isPlayerVisible(Vector3Int playerCurrentLocation)
    {
        Vector3 EnemeyPrefabPosition = transform.position;
        EnemeyPrefabPosition.y = 2f;
        playerCurrentLocation.y = 2;

        if (Physics.Raycast(transform.position, (playerCurrentLocation - transform.position).normalized, out RaycastHit hitinfo, RayDistance))
        {
            Debug.DrawRay(transform.position, (playerCurrentLocation - transform.position).normalized * hitinfo.distance, Color.blue);

            Debug.Log(hitinfo.transform.position);

            if (hitinfo.transform.name != "Wall" || hitinfo.transform.name != "wall")
            {
                Debug.Log("Player is Visble");
            }

            else
            {
                Debug.Log("Player isn't visble");
            }
        }
            return visible;
    }
    */

    
    
}
