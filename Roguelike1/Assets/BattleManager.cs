using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public bool InbattleMode = false;

    [SerializeField] private int currentCombo;
    [SerializeField] private PlayerUI playerUI;

    // game events
    [SerializeField] private GameEvent SwitchToPlayer;
    [SerializeField] private GameEvent SwitchToEnemy;


    private float damagemultiplier;
    private Player player;
    private Unit playerUnit;


    // instance 
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
        PlayerDoDamage(Enemy);

    }

    public void CollectData()
    {
        player = FindAnyObjectByType<Player>();
        playerUnit = player.GetComponent<Unit>();

    }

    public void PlayerDoDamage(Unit target)
    {
        int DamageValue = ComboCalculation(target);
        bool isDead = target.TakeDamage(DamageValue);
        if (isDead)
        {
            Destroy(target.gameObject);
        }
        DecreaseEnergy(playerUnit, 2);
        UpdateUI();
    }
    public void EnemyDoDamage(Unit Attacker)
    {
        int DamageValue = Attacker.Damage;
        bool isDead = playerUnit.TakeDamage(DamageValue);
        if (isDead)
        {
            Destroy(playerUnit.gameObject);
        }
        DecreaseEnergy(Attacker, 3);
        UpdateUI();
    }

    public void DecreaseEnergy(Unit Attacker, int Energy)
    {
        bool isOutOfEnergy = Attacker.LoseEnergy(Energy);

        if(isOutOfEnergy)
        {
            Debug.Log("Is out of energy");
            SwitchToEnemy?.Invoke();
        }

        UpdateUI();
    }

    private int ComboCalculation(Unit attacker)
    {
        currentCombo++;
        damagemultiplier = 1.0f;
        int attackerDamage = attacker.Damage;

        if (currentCombo < 3)
        {
            damagemultiplier = 1.0f;
        }
        else if(currentCombo >= 3 && currentCombo < 6)
        {
            damagemultiplier = 1.2f;
        }
        else if(currentCombo >= 6 && currentCombo < 8)
        {
            damagemultiplier = 1.6f;
        }
        else if(currentCombo >= 8)
        {
            damagemultiplier = 2.0f;
        }

        int newdamageValue = Mathf.RoundToInt(attackerDamage * damagemultiplier);

        return newdamageValue;

    }

    public void UpdateUI()
    {
        playerUI.CurrenthealthText.SetText(playerUnit.CurrentHP.ToString());
        playerUI.CurrentEnergyText.SetText(playerUnit.CurrentEnergy.ToString());
        playerUI.DamagemultiplierText.SetText(damagemultiplier + " X");

        //playerUI.CurrentTurnText.SetText()
    }

    private void EnemyTurnHandler()
    {

    }

}
