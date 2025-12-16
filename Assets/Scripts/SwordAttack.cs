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
