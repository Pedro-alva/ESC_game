using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // create a instance of gameManager to be accessed anywhere
    public static GameManager instance;
    public int gameLevel;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        //Everytime a scene is loaded the game is saved
        SceneManager.sceneLoaded += LoadState;

        DontDestroyOnLoad(gameObject);

    }

    //Resources list to save



    // References
    public Unit player;

    //Logic to track amount of something
    public string playerName;
    public int maxHealth;
    public int health;
    public int str;
    public int defense;
    public int skill;
    public int speed;
    public int luck;
    public int mana;


    public void SaveState()
    {
        //SceneManager.sceneLoaded -= SaveState;
        string saving = "";
        saving += player.unitName + "|";
        saving += player.maxHP.ToString() + "|";
        saving += player.currentHP.ToString() + "|";
        saving += player.strength.ToString() + "|";
        saving += player.defense.ToString() + "|";
        saving += player.skill.ToString() + "|";
        saving += player.speed.ToString() + "|";
        saving += player.luck.ToString() + "|";
        saving += player.mana.ToString() + "|";
        saving += SceneManager.GetActiveScene().buildIndex.ToString();
        PlayerPrefs.SetString("SaveState", saving);
        Debug.Log("SaveState");
    }
    public void LoadState(Scene stage, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        //create an array and fill it with the string data split with |
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');


        playerName = data[0];
        maxHealth = int.Parse(data[1]);
        health = int.Parse(data[2]);
        str = int.Parse(data[3]);
        defense = int.Parse(data[4]);
        skill = int.Parse(data[5]);
        speed = int.Parse(data[6]);
        luck = int.Parse(data[7]);
        mana = int.Parse(data[8]);
        gameLevel = int.Parse(data[9]);
        Debug.Log("LoadState");
    }
    public void LoadButton()
    {
        SceneManager.LoadScene(gameLevel + 1);
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}

