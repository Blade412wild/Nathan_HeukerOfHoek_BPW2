using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Transform Player;
    public Transform Enemy;
    public PathCalculator pathCalculator;
    public int HitRange = 2;

    private PlayerInputAction playerInputAction;

    private Vector3Int EnemyCurrentLocation;
    private Vector3Int playerCurrentLocation;
    private bool InRange;
    // Start is called before the first frame update
    void Start()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.FreeRoam.Enable();
        playerInputAction.FreeRoam.Click.performed += ctx => { OnMouseClick(); };
    }

    // Update is called once per frame
    //void Update()
    //{
    //    EnemyCurrentLocation = Vector3Int.RoundToInt(Enemy.position);
    //    Vector3Int playerCurrentLocation = Vector3Int.RoundToInt(Player.position);
        
    //    Vector3Int nextStep = pathCalculator.PathCalculation(playerCurrentLocation, EnemyCurrentLocation);
    //    Move(nextStep);
    //}

    public void OnMouseClick()
    {

            
            
                if (Vector3Int.Distance(playerCurrentLocation, EnemyCurrentLocation) < HitRange)
                {
                    Attack();
                }
                else
                {
                    Vector3Int nextStep = PathCalculation();
                    Move(nextStep);
                }
    }


    private void Attack()
    {
        Debug.Log("Attack");
    }

    private Vector3Int PathCalculation()
    {
        EnemyCurrentLocation = Vector3Int.RoundToInt(Enemy.position);
        playerCurrentLocation = Vector3Int.RoundToInt(Player.position);

        Vector3Int nextStep = pathCalculator.PathCalculation(playerCurrentLocation, EnemyCurrentLocation);
        return nextStep;
        //Move(nextStep);
    }
    private void Move(Vector3Int nextStep)
    {
        Vector3Int EnemyTargetPosition = new Vector3Int(nextStep.x, nextStep.y, nextStep.z);
        Enemy.position = EnemyTargetPosition;
        EnemyCurrentLocation = EnemyTargetPosition;
    }


}
