using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerInputAction inputActions;
    private FSM fsm;
 
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerInputAction();
        inputActions.FreeRoam.Disable();
        inputActions.popMenu.Disable();
        inputActions.battleMode.Disable();
        inputActions.GameResult.Disable();



        fsm = new FSM(typeof(FreeRoamState), GetComponents<BaseState>());

    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
    }
}
