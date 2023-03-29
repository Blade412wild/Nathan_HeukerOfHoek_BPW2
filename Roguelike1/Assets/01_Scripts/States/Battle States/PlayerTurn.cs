using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PlayerTurn : BaseState
{
    public int EnergyRefillAmount;

    [SerializeField]
    private GameEvent MouseClicked;

    private BattleHUD playerHUD;
    private Unit PlayerUnit;
    private Player player;
    private PlayerInputAction playerInputAction;




    public override void OnEnter()
    {
        Debug.Log("PlayerTurn");
        PlayerUnit.CurrentEnergy = PlayerUnit.CurrentEnergy + EnergyRefillAmount;
        playerInputAction.FreeRoam.Click.performed += ctx => { ClickedMouse(); };
    }

    public override void OnExit()
    {
        playerInputAction.FreeRoam.Click.performed -= ctx => { ClickedMouse(); };
    }

    public override void OnUpdate()
    {

    }

    public void CollectData()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.FreeRoam.Enable();

        player = FindAnyObjectByType<Player>();
        PlayerUnit = player.GetComponent<Unit>();
        //playerHUD = FindAnyObjectByType<BattleHUD>();
        //playerHUD.SetHUD(PlayerUnit);

        Debug.Log("collected Data");
    }

    public void ClickedMouse()
    {
        Debug.Log("Clicked Mouse");
        MouseClicked?.Invoke();
    }
}
