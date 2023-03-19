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
        dungeon = new Dictionary<Vector3Int, TileType>();
        currentLocation = Vector3Int.RoundToInt(transform.position);
        //Debug.Log(currentLocation.x);
        //Debug.Log(currentLocation.z);

        dungeon = DungeonGeneration.dungeon;
        TileType currentLocationValue = dungeon[currentLocation];
        Debug.Log(currentLocation);
        Debug.Log(currentLocationValue);
    }

    private void Update()
    {
        
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
        int TargetPositionX = currentLocation.x + moveDirection.x;
        int TargetPositionY = currentLocation.z + moveDirection.y;
        Vector3Int TargetPosition = new Vector3Int(TargetPositionX, 0, TargetPositionY);
        TileType TargetPositionValue = dungeon[currentLocation];
        Debug.Log(TargetPosition);
        Debug.Log(TargetPositionValue);

        if( TargetPositionValue == TileType.Floor)
        {
            Move(TargetPosition);
        }

     
    }
   
   private void Move(Vector3Int TargetPositionr)
   {
        transform.position = TargetPositionr;
   }
    

    

}
