using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int currentHP;
    public int maxHP;
    private GameObject hitEffect;

    private void Start()
    {
        maxHP = 100;
        currentHP = maxHP;
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
        if (hitEffect != null)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "HitEffect") // сравнение по имени
                {
                    Destroy(child.gameObject);
                }
            }
        }
        Vector3 spawnPos = new Vector3(0, 1, 0);

        Debug.Log($"{name} погиб!");
        gameObject.transform.position = spawnPos;
    }
}
