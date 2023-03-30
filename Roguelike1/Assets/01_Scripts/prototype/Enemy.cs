using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Range;
    public int HitRange;
    public int RayDistance;

    [SerializeField]
    private GameEvent PlayerInRange;

    private PlayerMovement playerMovement;
    private Player player;
    private bool visible;
    private PathFinding pathFinding;
    private bool InRange = false;
    private Vector3Int playerCurrentLocation;
    private Vector3Int enemyLocation;



    private void OnEnable()
    {
        player = FindAnyObjectByType<Player>();
        playerMovement = player.GetComponent<PlayerMovement>();
        pathFinding = GetComponent<PathFinding>();
    }


    //Checked of de Speler in de Buurt is van de Enemy
    public void CheckIfPlayerIsInRange()
    {
        Vector3Int playerCurrentLocation = playerMovement.currentLocation;
        PlayerDistance(playerCurrentLocation);
    }
    private void Update()
    {
        
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
            PlayerInRange?.Invoke();
            pathFinding.FindPathPlayer();
            InRange = true;


        }
    }

    public void EnemyTurn()
    {
        if (InRange)
        {

            if(Vector3Int.Distance(playerCurrentLocation, enemyLocation) < HitRange)
            {
                Attack();
            }
            else
            {
                Move();
            }
        }

    }

    private void Move()
    {

    }

    private void Attack()
    {

    }
    
}
