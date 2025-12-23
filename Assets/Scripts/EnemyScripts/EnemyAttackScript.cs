using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    //Transform
    public Transform Player;


    //GameObjects
    public GameObject Sword;


    //Scripts
    public PlayerScript PlayerScript;


    //Data
    public bool isTriggered = false;
    public bool cd;
    public float cdTime;
    public bool isAttacking = false;


    private void Start()
    {
        PlayerScript = Player.GetComponent<PlayerScript>();
        Sword = transform.parent.GetChild(0).gameObject;
    }


    private void Update()
    {
        if (isTriggered && cd == false)
        {
            Animator anim = Sword.GetComponent<Animator>();
            anim.SetTrigger("Attack");
            isAttacking = true;
            cd = true;
            Debug.Log("Punch");
            StartCoroutine(ResetCooldown());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }

    IEnumerator ResetCooldown()
    {
        StartCoroutine(WaitForDamage());
        yield return new WaitForSeconds(cdTime);
        cd = false;
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(0.4f);
        isAttacking = true;
        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.4f);
        isAttacking = false;
    }
}
