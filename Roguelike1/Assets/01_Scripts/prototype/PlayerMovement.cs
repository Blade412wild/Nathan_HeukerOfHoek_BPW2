using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleDungeon;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public  DungeonGeneratorSimple DungeonGeneration;

    private PlayerInputAction PlayerInput;
    //private Transform trans;
    private Vector3Int currentLocation;
    private Dictionary<Vector3Int, TileType> dungeon;
    private Vector2Int moveDirection;

    private void Awake()
    {

        PlayerInput = new PlayerInputAction();
        PlayerInput.Player.Enable();
        PlayerInput.Player.Movement.performed += ctx => { Movement(); };

    }

    private void Start()
    {
        currentLocation = Vector3Int.RoundToInt(transform.position);
        //currentLocation = DungeonGeneration.spawnpointCenter;
        TileType currentLocationValue = DungeonGeneration.TileTypeTest(currentLocation);
        //Debug.Log(currentLocation.x);
        //Debug.Log(currentLocation.z);
        Debug.Log(currentLocation + "dit komt uit PlayerMovement Script");

        dungeon = DungeonGeneration.dungeon;

        //Debug.Log(dungeon); // Ik weet niet hoe ik een dictionary kan gebruiken over meerdere scripts;
        
        //TileType currentLocationValue = dungeon[currentLocation];
        Debug.Log(currentLocation);
        //Debug.Log(currentLocationValue);
    }
    private void Movement()
    {
        moveDirection = Vector2Int.RoundToInt(PlayerInput.Player.Movement.ReadValue<Vector2>());
        moveDirection.x = Mathf.RoundToInt(moveDirection.x);
        moveDirection.y = Mathf.RoundToInt(moveDirection.y);
        IsPossibleToMove();

    }

   
    private void IsPossibleToMove()
    {
        // hier doe ik de Vector2 Input + mijn current
        int TargetPositionX = currentLocation.x + moveDirection.x;
        int TargetPositionY = currentLocation.z + moveDirection.y;
        Vector3Int TargetPosition = new Vector3Int(TargetPositionX, 0, TargetPositionY);
        Debug.Log(TargetPosition);
        TileType TargetPositionValue = DungeonGeneration.TileTypeTest(TargetPosition);
        //Debug.Log(TargetPosition); 
        //Debug.Log(TargetPositionValue);
        /*
        if( TargetPositionValue == TileType.Floor)
        {
            Move(TargetPosition);
        }
        */


    }
   
   private void Move(Vector3Int TargetPosition)
   {
        transform.position = TargetPosition;
        currentLocation = TargetPosition;
   }
    

    

}
