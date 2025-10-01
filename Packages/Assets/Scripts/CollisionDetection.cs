using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public SwordAttack SA;
    public GameObject HitParticle;
    public WeaponStats Stats;
    public bool db = false;


    private void OnTriggerEnter(Collider other)
    {
        EnemyScript enemy = other.GetComponent<EnemyScript>();
        if (other.tag == "Enemy" && SA.isAttacking && !db)
        {
            db = true;
            Debug.Log(other.name);

            Vector3 hitPoint = other.ClosestPoint(transform.position);

            
            GameObject hitEffect = Instantiate(
                HitParticle,
                hitPoint,
                Quaternion.identity
            );

            hitEffect.transform.SetParent(other.transform);
            enemy.SetHitEffect(hitEffect);
            enemy.TakeDamage(Stats.damage);
            StartCoroutine(ResetDb());
        }
    }

    IEnumerator ResetDb()
    {
        yield return new WaitForSeconds(1.5f);
        db = false;
    }
}
