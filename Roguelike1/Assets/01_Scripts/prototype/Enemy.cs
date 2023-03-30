using SimpleDungeon;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.WSA;

public class Enemy : MonoBehaviour
{
    public int Range;
    public int HitRange;
    public int RayDistance;

    public int RoomIndex;
    public bool IsActive;

    [SerializeField]
    private GameEvent PlayerInRange;

    private PlayerMovement playerMovement;
    private Player player;
    private bool visible;
    private PathFinding pathFinding;
    private bool InRange = false;
    private Vector3Int playerCurrentLocation;
    private Vector3Int enemyCurrentLocation;
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
            InRange = true;
            StartEnemyTurn();
        }
    }

    public void EnemyTurn()
    {
        enemyCurrentLocation = Vector3Int.RoundToInt(transform.position);

        if (InRange)
        {
            ActivateEnemiesInRoom();

            if(EnemyUnit.CurrentEnergy > 0)
            {
                if (Vector3Int.Distance(playerCurrentLocation, enemyCurrentLocation) < HitRange)
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
        Vector3Int EnemyTargetPosition = new Vector3Int(nextStep.x, nextStep.y, nextStep.z);
        transform.position = EnemyTargetPosition;
        enemyCurrentLocation = EnemyTargetPosition;
    }

    private void Attack()
    {
        BattleManager.Instance.EnemyDoDamage(EnemyUnit);
    }
    public void ActivateEnemiesInRoom()
    {
        Debug.Log("ActivateEnemiesinRoom");
        for (int i = 0; i < BattleManager.Instance.NormalEnemyList.Count; i++)
        {
            if (BattleManager.Instance.NormalEnemyList[i].RoomIndex == RoomIndex)
            {
                BattleManager.Instance.currentEnemiesActvive.Add(BattleManager.Instance.NormalEnemyList[i]);
            }
        }
    }

    private void StartEnemyTurn()
    {
        ActivateEnemiesInRoom();
    }


}
