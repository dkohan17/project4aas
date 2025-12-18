using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopToAttackScript : MonoBehaviour
{
    //Transform
    public Transform Enemy;

    //Scripts
    public SpotPlayerScript SpotPlayerScript;
    public StopHuntingScript StopHuntingScript;

    //Data
    public bool isTriggered = false;

    private void Start()
    {
        Enemy = transform.parent;
        StopHuntingScript = Enemy.GetComponentInChildren<StopHuntingScript>();
        SpotPlayerScript = Enemy.GetComponentInChildren<SpotPlayerScript>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            SpotPlayerScript.spotted = false;
            StartCoroutine(WaitAndMoveNext());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }

    IEnumerator WaitAndMoveNext()
    {
        yield return new WaitForSeconds(1f);
        if (StopHuntingScript.isTriggered && isTriggered == false)
        {
            SpotPlayerScript.spotted = true;
        }
    }
}
