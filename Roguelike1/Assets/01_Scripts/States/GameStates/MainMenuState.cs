using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MainMenuState : BaseState // misschien buiten de FSM houden voor irritatie;
{
    public Canvas MainCanvas;

    private PlayerInputAction inputActions;

    private void Start()
    {
        inputActions = new PlayerInputAction();
        
    }
    public override void OnEnter()
    {
        inputActions.Menu.Enable();
    }

    public override void OnExit()
    {
        inputActions.Menu.Disable();

    }

    public override void OnUpdate()
    {
        // if button start is pressed in canvas
    }
}
