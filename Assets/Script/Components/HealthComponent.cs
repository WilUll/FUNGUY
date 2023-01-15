using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float health = 30f;
    
    public bool TakeDamage(float damage)
    {
        health -= damage;
        bool isDead = health <= 0;
        if (isDead) Die();
        return isDead;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
