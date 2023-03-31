using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : BaseState
{
    public override void OnEnter()
    {
        BattleManager.Instance.InbattleMode = true;

        Debug.Log("Enemyturn");
        CollectData();
        BattleManager.Instance.StartEnemyTurn();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        
    }
   

    private void CollectData()
    {

    }

    public void SwitchToPlayer()
    {
        owner.SwitchState(typeof(PlayerTurn));
    }
}
