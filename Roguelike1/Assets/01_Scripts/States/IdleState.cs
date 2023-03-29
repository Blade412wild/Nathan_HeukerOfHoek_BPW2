using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void OnEnter()
    {
        Debug.Log("Idele State");
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
        Debug.Log("switch to playerTurn");
        owner.SwitchState(typeof(PlayerTurn));
    }


}
