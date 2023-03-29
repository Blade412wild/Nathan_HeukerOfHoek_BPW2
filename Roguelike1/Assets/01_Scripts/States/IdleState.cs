using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private Unit PlayerUnit;
    private Player player;

    public override void OnEnter()
    {
        Debug.Log("Idele State");
        BattleManager.Instance.InbattleMode = false;

    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }

    void Start()
    {
        
    }

    public void PlayerInRange()
    {
        if (!BattleManager.Instance.InbattleMode)
        {
            owner.SwitchState(typeof(PlayerTurn));
        }
    }
    public void CollectData()
    {
        player = FindAnyObjectByType<Player>();
        PlayerUnit = player.GetComponent<Unit>();
        //playerHUD = FindAnyObjectByType<BattleHUD>();
        //playerHUD.SetHUD(PlayerUnit);

        //Debug.Log("collected Data");
    }


}
