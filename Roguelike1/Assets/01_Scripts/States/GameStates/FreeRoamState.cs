using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRoamState : BaseState
{
    private PlayerInputAction inputActions;

    private void Start()
    {
        inputActions = new PlayerInputAction();

    }
    public override void OnEnter()
    {
        inputActions.FreeRoam.Enable();
    }

    public override void OnExit()
    {
        inputActions.FreeRoam.Disable();

    }

    public override void OnUpdate()
    {
    }

    public void OnWin()
    {
        // if de speler in het portaal komt met de key gaat de state naar GameResult
    }
    
    public void InRange()
    {
        // wanneer de player in de range komt van de enemy, ga dan naar battleModeState

    }
}
