using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // for TextMeshPro text!

public class Unit : MonoBehaviour
{
    public string unitName;
    public int maxHP; // the max HP the unit can have
    public int currentHP; // used to keep trackof HP as battle ends

    public int strength; // raw attack power
    public int defense; // used to reduce attack damange received
    public int skill; // for chance to hit enemy, and land critical attacks
    public int speed; // determines whow ill go first in battle
    public int luck; // used for chance to hit, dodge, run away
    public int mana; // ensures that powerful attacks can not be used

    /*
     * In future sprint, need to create multiple functions to handle all
     * of the different combat variables and options. For now only
     * attack with chance for critical hit has been added.
     * 
     * */


    public bool TakeDamage(int opponentDamage, int opponentSkill)
    {
        /*
         *  The way the critical system works is by:
         *  - get random number (0 - 100) from Random class
         *  - compare number with (unit skill / 2)
         *  - if unit skill is higher than the random number
         *  - then attack is doubled
         */
        var randomNum = new System.Random();
        int critCheck = randomNum.Next(0, 100); // get random num between 0 and n

        // following if-else will be used to determine if critical hit dealt
        /* In the future, I want to display in dialogue box when critical hit happens.
            I am still unsure on how to do this.*/
        if ((opponentSkill / 2) >= critCheck)
            currentHP = currentHP - ((opponentDamage * 2) - defense); // does double damage!
        

        else
            currentHP = currentHP - (opponentDamage - defense);


        // following code to see if unit has died
        if (currentHP <= 0)
            return true;

        else
            return false;
    }
}
