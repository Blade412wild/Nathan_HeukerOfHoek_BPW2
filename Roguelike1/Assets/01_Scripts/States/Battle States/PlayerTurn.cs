using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : BaseState
{
    private BattleHUD playerHUD;
    private Unit PlayerUnit;
    private Player player;
    private PlayerInputAction playerInputAction;
    public override void OnEnter()
    {
       if(player == null)
       {
            playerSetUP();
            InputSetUp();
       }



    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
    private void playerSetUP()
    {
        playerHUD = FindAnyObjectByType<BattleHUD>();
        player = FindAnyObjectByType<Player>();
        PlayerUnit = player.GetComponent<Unit>();
        playerHUD.SetHUD(PlayerUnit);
    }

    private void InputSetUp()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.FreeRoam.Disable();
        playerInputAction.battleMode.Enable();

    }
}
