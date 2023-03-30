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
    private Unit EnemyUnit;
    private PathCalculator pathCalculator;



    private void OnEnable()
    {
        player = FindAnyObjectByType<Player>();
        playerMovement = player.GetComponent<PlayerMovement>();
        pathFinding = GetComponent<PathFinding>();
        pathCalculator = GetComponent<PathCalculator>();

    }


    //Checked of de Speler in de Buurt is van de Enemy
    public void CheckIfPlayerIsInRange()
    {
        playerCurrentLocation = playerMovement.currentLocation;
        PlayerDistance(playerCurrentLocation);
        EnemyUnit = GetComponent<Unit>();
    }
    private void Update()
    {
        
    }

    private Vector3Int PathCalculation()
    {
        Vector3Int EnemyLocation = Vector3Int.RoundToInt(transform.position);
        Vector3Int nexStep = pathCalculator.PathCalculation(playerCurrentLocation, EnemyLocation);

        return nexStep;
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
            if(EnemyUnit.CurrentEnergy > 0)
            {
                if (Vector3Int.Distance(playerCurrentLocation, enemyLocation) < HitRange)
                {
                    Attack();
                }
                else
                {
                    Vector3Int nextStep = PathCalculation();
                    Move(nextStep);
                }
            }

        }

    }

    private void Move(Vector3Int nextStep)
    {
        
    }

    private void Attack()
    {
        BattleManager.Instance.EnemyDoDamage(EnemyUnit);
    }
    
}
