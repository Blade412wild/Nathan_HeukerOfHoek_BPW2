using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private FSM fsm;
    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM(typeof(StartState), GetComponents<BaseState>());
        Debug.Log(fsm.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
    }
}
