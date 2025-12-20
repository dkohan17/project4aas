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


    private void Start()
    {
        StateAliveOrDead = transform.GetComponent<EnemyStateAliveOrDeadScript>();
    }

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

    public void Despawn()
    {
        cd = 10;
        StateAliveOrDead.SetState("Dead");
        transform.SetParent(firstParent);
        transform.position = new Vector3(2.159912f, -6.513f, 0f);
        StartCoroutine(ResetSpawnCD());
        Debug.Log("Despawn");
    }

    IEnumerator ResetSpawnCD()
    {
        yield return new WaitForSeconds(cd);
        cd = 0;
    }
}
