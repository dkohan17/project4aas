using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public GameObject Sword;
    public ShieldBlockScript SBS;
    public bool CanAttack = true;
    public float AttackCooldown = 2.0f;
    public bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack && !SBS.IsBlocking)
            {
                Attack();
            }
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

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
    }

}
