using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyCollisionDetection1 : MonoBehaviour
{
    public EnemySwordAttack1 SA;
    public ShieldBlockScript ShieldBlockScript;
    public GameObject HitParticle;
    public WeaponStats Stats;
    public bool db = false;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        PlayerScript enemy = other.GetComponent<PlayerScript>();
        Debug.Log("a");
        if (other.tag == "Player" && SA.isAttacking && !db)
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
            if (ShieldBlockScript.IsBlocking)
            {
                enemy.TakeDamage(Stats.damage - 20);
            }
            else
            {
                enemy.TakeDamage(Stats.damage);
            }
            StartCoroutine(ResetDb());
        }
    }

    IEnumerator ResetDb()
    {
        yield return new WaitForSeconds(1.5f);
        db = false;
    }
}
