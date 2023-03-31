using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private GameEvent UpdateUI;


    private Unit playerUnit;

    private void Start()
    {
        playerUnit = GetComponent<Unit>();
    }
    public void RegainHealth(int healthRegain)
    {
        playerUnit.CurrentHP = playerUnit.CurrentHP + healthRegain;

        if(playerUnit.CurrentHP > playerUnit.MaxHP)
        {
            playerUnit.CurrentHP = playerUnit.MaxHP;
        }
        BattleManager.Instance.UpdateUI();
    }
}
