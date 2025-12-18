using System.Collections;
using UnityEngine;

public class ShieldBlockScript : MonoBehaviour
{
    [SerializeField] GameObject Shield;
    [SerializeField] float Cooldown = 2f;

    public SwordAttack SA;

    public bool CanBlock = true;
    public bool IsBlocking = false;
    public bool db = false;

    Animator anim;
    Coroutine blockingRoutine;

    void Awake()
    {
        if (Shield == null) Debug.LogError("Shield не назначен в инспекторе!");
        else anim = Shield.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && CanBlock && !IsBlocking && !SA.isAttacking)
        {
            if (Shield.transform.GetComponent<MeshRenderer>().enabled)
            {
                StartBlock();
                db = true;
                StartCoroutine(ResetDb());
            }
        }

        if (Input.GetMouseButtonUp(1) && IsBlocking && !db)
        {
            StopBlock();
        }

        if (!Shield.transform.GetComponent<MeshRenderer>().enabled)
        {
            StopBlock();
        }
    }

    void StartBlock()
    {
        if (db) return;
        IsBlocking = true;
        Debug.Log("Block");
        if (anim) anim.SetTrigger("Block");
        anim.SetTrigger("BlockingIdle");
    }

    void StopBlock()
    {
        IsBlocking = false;

        if (blockingRoutine != null)
        {
            StopCoroutine(blockingRoutine);
            blockingRoutine = null;
        }

        if (anim) anim.SetTrigger("BlockStopped");
        

        StartCoroutine(BlockCooldown());
    }

    System.Collections.IEnumerator BlockCooldown()
    {
        CanBlock = false;
        yield return new WaitForSeconds(Cooldown);
        CanBlock = true;
    }

    IEnumerator ResetDb()
    {
        yield return new WaitForSeconds(0.2f);
        db = false;
    }

    IEnumerator BlockingIdle()
    {
        yield return new WaitForSeconds(1f);
    }
}