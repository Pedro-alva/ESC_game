using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals :Collidable
{
  protected override void OnCollide(Collider2D coll)
  {
    if (coll.name == "Temp Slime")
    {
      //Teleport the player to next scene
      GameManager.instance.SaveState();
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }
}
//