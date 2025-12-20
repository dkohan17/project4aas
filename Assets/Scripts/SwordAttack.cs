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
    public Transform inventory;

    void Update()
    {
        foreach (Transform slot in inventory)
        {
            foreach (Transform tool in slot)
            {
                if (tool.CompareTag("Sword"))
                {
                    Sword = tool.gameObject;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Sword == null) return;
            if (CanAttack && !SBS.IsBlocking)
            {
                if (Sword.transform.GetComponent<MeshRenderer>().enabled)
                {
                    Attack();
                }
            }
        }
        if (isAttacking && !Sword.transform.GetComponent<MeshRenderer>().enabled)
        {
            isAttacking = false;
        }
    }


    public void Attack()
    {
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(WaitForDamage());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(0.4f);
        isAttacking = true;
        StartCoroutine(ResetAttackBool());
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.1f);
        isAttacking = false;
    }

}
