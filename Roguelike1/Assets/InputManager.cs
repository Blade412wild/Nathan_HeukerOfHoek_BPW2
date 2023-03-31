using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInputAction InputAction;



    public static InputManager Instance = null;

    void Start()
    {
        InputAction = new PlayerInputAction();
    }

    public void FreeRoamState()
    {

    }

    public void BattleModeState()
    {

    }

    public void WinState()
    {

    }

    public void LoseState()
    {

    }




}
