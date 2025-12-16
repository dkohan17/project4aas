using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopHuntingScript : MonoBehaviour
{
    //Transform
    public Transform Enemy;

    //Scripts
    public WalkEnemyScript WalkEnemyScript;
    public SpotPlayerScript SpotPlayerScript;


    private void Start()
    {
        Enemy = transform.parent;
        WalkEnemyScript = Enemy.GetComponent<WalkEnemyScript>();
        SpotPlayerScript = Enemy.GetComponentInChildren<SpotPlayerScript>();
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpotPlayerScript.spotted = false;
            WalkEnemyScript.enabled = true;
        }
    }
}
