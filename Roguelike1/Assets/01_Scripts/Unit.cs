using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string UnitName;
    public int UnitLevel;

    public int Damage;

    public int MaxHP;
    public int CurrentHP;
    public int MaxEnergy;
    public int CurrentEnergy;
    public Text CurrentTurn;

    public bool TakeDamage(int dmg)
    {
        CurrentHP -= dmg;

        if(CurrentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool LoseEnergy(int Energy)
    {
        CurrentEnergy -= Energy;

        if(CurrentEnergy <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
