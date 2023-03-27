using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private FSM fsm;
 
    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM(typeof(Start), GetComponent<BaseState>());

    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate();
    }
}
