using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // for TextMeshPro text!
using UnityEngine.SceneManagement;

// the turn-based battle can have these possible outcomes
public enum BattleState { START, PLAYER_TURN, ENEMY_TURN, WON, LOST, ESCAPED }

public class TurnBasedBattleSystem : MonoBehaviour
{
    public BattleState status;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    // Used to set information in HUDs
    public BattleHudScript playerHUD;
    public BattleHudScript enemyHUD;


    // Creating Unit objects to store and display information
    Unit playerUnit;
    Unit enemyUnit;

    // Following variables are for displaying information on text fields
    public TextMeshProUGUI dialogueText;


    // "Grabbing" buttons to enable and disable them when player chooses action
    public Button attackButton;
    public Button escapeButton;


    // Start is called before the first frame update
    void Start()
    {
        status = BattleState.START;
        StartCoroutine(SetUpBattle());
    }


    IEnumerator SetUpBattle()
    {
        // Creating objects so they may be referenced
        //Instantiate means spawn
        GameObject playerStart = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerStart.GetComponent<Unit>();

        GameObject enemyStart = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyStart.GetComponent<Unit>();

        // displayed on dialogue box at start of battle
        dialogueText.text = enemyUnit.unitName + " readies for battle!";

        // set unit names
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        // set respective unit's HP
        playerHUD.SetHP(playerUnit.currentHP, playerUnit.maxHP);
        enemyHUD.SetHP(enemyUnit.currentHP, enemyUnit.maxHP);



        yield return new WaitForSeconds(3f); // wait 3 seconds between iterations

        // Following logic is for determining who goes first in fight
        if (playerUnit.speed >= enemyUnit.speed)
        {
            status = BattleState.PLAYER_TURN;
            PlayerTurn();
        }

        // if enemy has greater speed
        else
        {
            status = BattleState.ENEMY_TURN;
            StartCoroutine(EnemyTurn());

        }
    }


    IEnumerator PlayerAttack()
    {
        bool enemyDead = enemyUnit.TakeDamage(playerUnit.strength, playerUnit.skill);
        dialogueText.text = "Enemy hit!";

        // set new HP
        enemyHUD.SetHP(enemyUnit.currentHP, enemyUnit.maxHP);

        // we need to disable button so player is not able to keep attacking
        attackButton.interactable = false;

        yield return new WaitForSeconds(2f);

        if (enemyDead)
        {
            status = BattleState.WON;
            EndBattle();
        }

        else
        {
            // enemy turn to do something
            status = BattleState.ENEMY_TURN;
            StartCoroutine(EnemyTurn());
        }
    }


    void PlayerTurn()
    {
        dialogueText.text = "Choose action:";
        attackButton.interactable = true;
    }


    IEnumerator EnemyTurn()
    {
        // enemy AI can do a lot
        // For sprint #2, will just attack
        yield return new WaitForSeconds(1f);

        dialogueText.text = enemyUnit.unitName + " attacked!";

        yield return new WaitForSeconds(1f);

        bool playerDead = playerUnit.TakeDamage(enemyUnit.strength, enemyUnit.skill);

        // set new hp
        playerHUD.SetHP(playerUnit.currentHP, playerUnit.maxHP);


        yield return new WaitForSeconds(1f);

        if (playerDead)
        {
            status = BattleState.LOST;
            EndBattle();
        }

        else
        {
            status = BattleState.PLAYER_TURN;
            PlayerTurn();
        }
    }


    /*
     * Following code is for dialogue box HUD buttons
     * 
     * 
     */

    public void OnAttackButton()
    {
        if (status != BattleState.PLAYER_TURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnEscapeButton(string sceneName)
    {
        var randomNum = new System.Random();
        int escapeCheck = randomNum.Next(0, 100); // get random num between 0 and n

        if ((playerUnit.luck * 3) >= (escapeCheck / 2))
        {
            status = BattleState.ESCAPED;
            EndBattle();
            SceneManager.LoadScene(sceneName); // leaves battle scene
        }

        // else...
        status = BattleState.ENEMY_TURN;
        StartCoroutine(EnemyTurn());
    }


    /*
     * For any occasion that battle ends
     * 
     */

    void EndBattle()
    {
        if (status == BattleState.WON)
        {
            dialogueText.text = "Victory Attained!";
        }

        else if (status == BattleState.LOST)
        {
            dialogueText.text = "Your hopes of escaping are fading...";
        }

        if (status == BattleState.ESCAPED)
        {
            dialogueText.text = "YOU ESCAPED!!";
        }

        // implement algorithm to Scene switch depending on battle outcome
        // i.e. switch to main map scene if we win, or whatever scene we choose if we lose
    }
}
