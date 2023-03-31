using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleDungeon;
using Unity.Mathematics;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    public Player player;
    private PlayerInputAction PlayerInput;
    public Vector3Int currentLocation;
    private Dictionary<Vector3Int, TileType> dungeon;
    private Vector2Int moveDirection;

    // Events 
    [SerializeField]
    private GameEvent OnMove;
    [SerializeField]
    private GameEvent OnPlayerSpawn;

    private void Awake()
    {
        PlayerInput = new PlayerInputAction();
        PlayerInput.FreeRoam.Enable();
        PlayerInput.FreeRoam.Movement.performed += ctx => { Movement(); };

    }

    private void Start()
    {
        currentLocation = Vector3Int.RoundToInt(transform.position);
        OnPlayerSpawn?.Invoke();
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
        moveDirection = Vector2Int.RoundToInt(PlayerInput.FreeRoam.Movement.ReadValue<Vector2>());
        IsPossibleToMove();
    }

    private void IsPossibleToMove()
    {
        int TargetPositionX = currentLocation.x + moveDirection.x;
        int TargetPositionY = currentLocation.z + moveDirection.y;
        Vector3Int TargetPosition = new Vector3Int(TargetPositionX, 0, TargetPositionY);
        TileType TargetPositionValue = dungeon[TargetPosition];

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
        OnMove?.Invoke();

   }

    public void SwitchToPlayerTurn()
    {
        PlayerInput.FreeRoam.Movement.performed += ctx => { Movement(); };
    }

    public void SwitchToEnemyTurn()
    {
        PlayerInput.FreeRoam.Movement.performed -= ctx => { Movement(); };
    }
}
