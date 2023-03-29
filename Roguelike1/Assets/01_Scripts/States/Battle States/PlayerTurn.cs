using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PlayerTurn : BaseState
{
    private BattleHUD playerHUD;
    private Unit PlayerUnit;
    private Player player;
    private PlayerInputAction playerInputAction;


    public override void OnEnter()
    {
        Debug.Log("PlayerTurn");
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if(PlayerUnit.CurrentEnergy == 0)
        {
            
        }
    }

    public void CollectData()
    {
        //player data
        player = FindAnyObjectByType<Player>();
        PlayerUnit = player.GetComponent<Unit>();
        //playerHUD = FindAnyObjectByType<BattleHUD>();
        //playerHUD.SetHUD(PlayerUnit);

        Debug.Log("collected Data");
    }
}
