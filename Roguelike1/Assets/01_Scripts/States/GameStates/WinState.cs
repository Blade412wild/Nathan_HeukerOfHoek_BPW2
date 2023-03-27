using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinState : BaseState
{
    private PlayerInputAction inputActions;

    public Canvas canvas;
    
    

    private void Start()
    {
        inputActions = new PlayerInputAction();

    }

    public override void OnEnter()
    {
        // zet canvas aan 

    }

    public override void OnExit()
    {
        // zet canvas uit

    }

    public override void OnUpdate()
    {

    }
}
