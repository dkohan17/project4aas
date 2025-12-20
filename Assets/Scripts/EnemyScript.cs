using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int currentHP;
    private GameObject hitEffect;

    private void Start()
    {
        currentHP = 100;
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
        }
    }

    private void Die()
    {
        if (hitEffect != null)
        {
            Destroy(hitEffect); // удаляем частицы
        }

        Debug.Log($"{name} погиб!");
        Destroy(gameObject);
    }
}
