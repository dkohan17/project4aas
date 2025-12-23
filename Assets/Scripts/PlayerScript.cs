using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int currentHP;
    public int maxHP;
    private GameObject hitEffect;
    private BloodPool bloodPool;

    private void Start()
    {
        maxHP = 100;
        currentHP = maxHP;
    }

    private void Awake()
    {
        //bloodPoolAI = FindObjectOfType<BloodPoolAI>();
        if (!bloodPool) bloodPool = FindObjectOfType<BloodPool>();
    }

    public void SetHitEffect(GameObject effect)
    {
        hitEffect = effect;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{name} получил {damage} урона. HP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
            currentHP = maxHP;
        }
    }

    private void Die()
    {
        var toDespawn = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.name == "BloodSprayFX(Clone)")
            {
                toDespawn.Add(child.gameObject);
            }
        }
        foreach (var go in toDespawn)
        {
            //bloodPoolAI.Despawn(go);
            if (bloodPool != null)
            {
                bloodPool.returnBlood(go);
            }
        }
        Vector3 spawnPos = new Vector3(0, 1, 0);

        Debug.Log($"{name} погиб!");
        gameObject.transform.position = spawnPos;
    }
}
