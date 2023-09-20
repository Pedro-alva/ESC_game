using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
  public GameObject enemy;
  public float interval = 120f;
    // Start is called before the first frame update
    void Start()
    {
      SpawnEnemy();
      StartCoroutine(respawnEnemy(interval, enemy));
    }

    public void SpawnEnemy() 
    {
      Instantiate(enemy, transform.position, Quaternion.identity);
    }
    private IEnumerator respawnEnemy(float wait, GameObject badguy)
    {
      yield return new WaitForSeconds(wait);
      Instantiate(badguy, transform.position, Quaternion.identity);
      StartCoroutine(respawnEnemy(wait, badguy));
    }
}
