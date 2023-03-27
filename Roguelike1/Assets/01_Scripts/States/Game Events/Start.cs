using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start : BaseState
{
    public bool win;
    public GameObject Player;
    public GameObject Enemy;

    public Transform PlayerBattleStation;
    public Transform EnemyBattleStation;

    private Unit playerUnit;
    private Unit EnemyUnit;

    public override void OnEnter()
    {
        Debug.Log("Entered StartState");
        SetupBattle();
    }

    public override void OnExit()
    {
  
    }

    public override void OnUpdate()
    {

    }

    private void SetupBattle()
    {
        GameObject PlayerGo = Instantiate(Player, PlayerBattleStation);
        GameObject EnemyGo = Instantiate(Enemy, EnemyBattleStation);

        playerUnit = PlayerGo.GetComponent<Unit>();
        EnemyUnit = EnemyGo.GetComponent<Unit>();

        owner.SwitchState(typeof(PlayerTurn));
    }
}

