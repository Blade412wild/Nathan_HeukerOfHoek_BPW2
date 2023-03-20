using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleDungeon;
using Unity.Mathematics;

public class PlayerMovement : MonoBehaviour
{
    public Player player;

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
        //Debug.Log(currentLocation.x);
        //Debug.Log(currentLocation.z);

        //dungeon = DungeonGeneration.dungeon;
        Debug.Log(dungeon);
        //TileType currentLocationValue = dungeon[currentLocation];
        Debug.Log(currentLocation);
        //Debug.Log(currentLocationValue);
    }

    public void SetupPlayer(DungeonGeneratorSimple dungeon)
    {
        this.dungeon = dungeon.dungeon;
    }

    private void Update()
    {
        
    }

    private void Movement()
    {
        moveDirection = Vector2Int.RoundToInt(PlayerInput.Player.Movement.ReadValue<Vector2>());
        //moveDirection.x = Mathf.RoundToInt(moveDirection.x);
        //moveDirection.y = Mathf.RoundToInt(moveDirection.y);
        IsPossibleToMove();

    }

   
    private void IsPossibleToMove()
    {
        int TargetPositionX = currentLocation.x + moveDirection.x;
        int TargetPositionY = currentLocation.z + moveDirection.y;
        Vector3Int TargetPosition = new Vector3Int(TargetPositionX, 0, TargetPositionY);
        Debug.Log(TargetPosition);
        TileType TargetPositionValue = dungeon[TargetPosition];
        Debug.Log(TargetPosition);
        Debug.Log(TargetPositionValue);

        if( TargetPositionValue == TileType.Floor)
        {
            Move(TargetPosition);
        }

     
    }
   
   private void Move(Vector3Int TargetPositionr)
   {
        quaternion rightrotation = Quaternion.Euler(0, 90, 0);
        quaternion leftRotation = Quaternion.Euler(0,-90,0);
        quaternion upRotation = Quaternion.Euler(0, 0, 0);
        quaternion downRotation = Quaternion.Euler(0, 180, 0);

        if (moveDirection == Vector2Int.up)
        {
            transform.rotation = upRotation;
        }
        else if(moveDirection == Vector2Int.down)
        {
            transform.rotation = downRotation;
        }
        else if(moveDirection == Vector2Int.left)
        {
            transform.rotation = leftRotation;
        }
        else if(moveDirection == Vector2Int.right)
        {
            transform.rotation = rightrotation;
        }
        transform.position = TargetPositionr;
        currentLocation = TargetPositionr;
   }
    

    

}
