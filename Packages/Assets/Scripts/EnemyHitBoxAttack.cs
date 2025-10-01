using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBoxAttack : MonoBehaviour
{
    public EnemySwordAttack1 ESA = new EnemySwordAttack1();

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("A");
        if (other.tag == "Player" && ESA.CanAttack)
        {
            Debug.Log("B");
            ESA.Attack();
        }
    }
}
