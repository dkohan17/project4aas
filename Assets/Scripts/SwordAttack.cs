using System.Collections;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public WeaponStats weaponStats;
    public GameObject Sword;

    public bool CanAttack = true;
    public float AttackCooldown = 2.0f;
    public bool isAttacking = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanAttack)
        {
            Attack();
        }
    }

    public void Attack()
    {
        isAttacking = true;
        CanAttack = false;

        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");

        StartCoroutine(ResetAttackCooldown());
    }

    public void DealDamage(Collider enemy)
    {
        if (enemy.TryGetComponent(out EnemyScript enemyScript))
        {
            enemyScript.TakeDamage(weaponStats.damage);
        }
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        isAttacking = false;
    }
}
