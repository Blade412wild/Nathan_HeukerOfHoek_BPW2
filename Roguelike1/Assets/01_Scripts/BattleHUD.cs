using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text CurrentHP;
    public Text CurrentEnergy;
    public Text CurrentTurn;

    public void SetHUD(Unit unit)
    {
        CurrentHP.text = unit.CurrentHP.ToString();
        CurrentEnergy.text = unit.CurrentEnergy.ToString();
        CurrentTurn.text = unit.CurrentTurn.ToString();


    }

    public void SetHP(int hp)
    {
        CurrentHP.text = hp.ToString();
    }
}
