using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public SwordAttack SA;
    public GameObject HitParticle;
    public WeaponStats Stats;
    public bool db = false;
    private BloodPool bloodPool;

    private void Awake()
    {
        //bloodPoolAI = FindObjectOfType<BloodPoolAI>();
        if (!bloodPool) bloodPool = FindObjectOfType<BloodPool>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && SA.isAttacking && !db)
        {
            EnemyScript enemy = other.GetComponent<EnemyScript>();
            db = true;

            Vector3 hitPoint = other.ClosestPoint(transform.position);

            Vector3 dir = hitPoint - transform.position;
            if (dir.sqrMagnitude < 1e-6f) dir = transform.forward;

            Vector3 hitNormal = Vector3.up;
            if (Physics.Raycast(transform.position, dir.normalized, out var hit, 3f, ~0, QueryTriggerInteraction.Ignore)
                && hit.collider == other)
            {
                hitPoint = hit.point;
                hitNormal = hit.normal;
            }

            Vector3 lateral = Vector3.ProjectOnPlane(hitNormal, Vector3.up);
            if (lateral.sqrMagnitude < 1e-4f)
                lateral = Vector3.ProjectOnPlane((hitPoint - transform.position).normalized, Vector3.up);

            lateral = -lateral;

            if (lateral.sqrMagnitude < 1e-6f) lateral = -transform.forward;
            lateral.Normalize();

            lateral = Quaternion.AngleAxis(Random.Range(-18f, 18f), Vector3.up) * lateral;

            //bloodPool.SpawnBlood(hitPoint, lateral, lifeTime: 0f, parent: other.transform, keepWorldPosition: true);
            if (bloodPool != null)
            {
                bloodPool.GetBlood(hitPoint, lateral, other.transform);
            }
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
