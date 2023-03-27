using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopMenuState : BaseState
{
    private PlayerInputAction inputActions;

    private void Start()
    {
        inputActions = new PlayerInputAction();

    }
    public override void OnEnter()
    {
        inputActions.popMenu.Enable();
    }

    public override void OnExit()
    {
        inputActions.popMenu.Disable();

    }

    public override void OnUpdate()
    {
        // De player kan op Back to Menu klikken of return to game klikken.
    }
}
