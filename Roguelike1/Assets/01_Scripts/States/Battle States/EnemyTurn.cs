using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : BaseState
{
    public override void OnEnter()
    {
        Debug.Log("Enemyturn");
        CollectData();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        
    }
   

    private void CollectData()
    {

    }
}
