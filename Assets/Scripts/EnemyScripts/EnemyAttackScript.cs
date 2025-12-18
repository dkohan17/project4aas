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
            cd = true;
            Debug.Log("Punch");
            StartCoroutine(GiveDamage());
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

    IEnumerator GiveDamage()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerScript.TakeDamage(10);
        StartCoroutine(ResetCooldown());
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cdTime);
        cd = false;
    }

}
