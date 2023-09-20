using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyPatrol : MonoBehaviour
{
  public float speed = 200f;
  public Transform[] targets;
  public Transform enemyGFX;
  public float nextWaypointDistance = 3f;

  Path path;
  int currentWaypoint = 0;
  bool reachEndOfPath = false;

  Seeker seeker;
  Rigidbody2D rb;
  private int randomSpot;

  private void Start()
  {
    randomSpot = Random.Range(0, targets.Length);
    seeker = GetComponent<Seeker>();
    rb = GetComponent<Rigidbody2D>();
    InvokeRepeating("UpdatePath", 0f, .5f);
    
  }
  void UpdatePath()
  {
    if (seeker.IsDone())
    {
      float reached = Vector2.Distance(rb.position, targets[randomSpot].position);
      
      seeker.StartPath(rb.position, targets[randomSpot].position, OnPathComplete);
      if (reached < 3)
      {
        randomSpot = Random.Range(0, targets.Length);
      }
      
    }
    
  }
  void OnPathComplete(Path p)
  {
    if(!p.error)
    {
      path = p;
      currentWaypoint = 0;
    }
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    transform.position = Vector2.MoveTowards(transform.position, targets[randomSpot].position, speed * Time.deltaTime);
    if(path == null)
    {
      return;
    }
    if(currentWaypoint >= path.vectorPath.Count)
    {
      reachEndOfPath = true;
      return;
    }
    else
    {
      reachEndOfPath = false;
    }

    Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
    Vector2 force = direction * speed * Time.deltaTime;
    rb.AddForce(force);
    float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
    if(distance < nextWaypointDistance)
    {
      currentWaypoint++;
    }
    if(force.x >= 0.01f)
    {
      enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
    }else if(force.x <= -0.01f)
    {
      enemyGFX.localScale = new Vector3(1f, 1f, 1f);
    }
  }
}
