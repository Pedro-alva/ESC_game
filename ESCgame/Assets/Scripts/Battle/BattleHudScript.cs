using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // for TextMeshPro text!


public class BattleHudScript : MonoBehaviour
{
    public TextMeshProUGUI nameText; // used to set name in both battle HUD
    public TextMeshProUGUI hpText; // used to set hp

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
    }


    // Set HP function to iterate everytime unit takes damage
    public void SetHP(int hp, int maxHP)
    {
        // following if is to avoid displaying negative health points
        if (hp < 0)
            hpText.text = 0 + "/" + maxHP;

        else
            hpText.text = hp + "/" + maxHP;
    }

}
