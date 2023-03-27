using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeState : BaseState
{
    private PlayerInputAction inputActions;

    private void Start()
    {
        inputActions = new PlayerInputAction();


    }
    public override void OnEnter()
    {
        inputActions.battleMode.Enable();

    }

    public override void OnExit()
    {
        inputActions.battleMode.Disable();

    }

    public override void OnUpdate()
    {

    }

    public void OnDead()
    {
        // switch naar lose state
    }

}
