using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public int DamageValue;

    [SerializeField]
    int currentCombo;

    public static BattleManager Instance = null;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void CurrentEnemy(Unit Enemy)
    {
        bool isDead = Enemy.TakeDamage(DamageValue);
        Debug.Log(Enemy.CurrentHP);
        if (isDead)
        {
            Destroy(Enemy.gameObject);
        }
    }


}
