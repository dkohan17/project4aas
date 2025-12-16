using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    //Scripts
    public EnemyStateAliveOrDeadScript StateAliveOrDead;


    public Collider spawnHitbox;
    public Transform player;
    public Transform firstParent;
    public Transform secondParent;


    public Transform spawnPoint;


    //Floats
    public float cd;

    private void Update()
    {
        if (transform.parent == firstParent && spawnHitbox.bounds.Contains(player.position) == false && cd == 0 )
        {
            StateAliveOrDead.SetState("Alive");
            transform.SetParent(secondParent);
            transform.position = spawnPoint.position;
            Debug.Log("Spawn");
        }
    }
}
