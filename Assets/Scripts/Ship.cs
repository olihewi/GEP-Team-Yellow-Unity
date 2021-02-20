using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float maxHealth = 1;
    public int scoreReward = 1;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float _damage, Ship _attacker)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            _attacker.OnDestroyOther(this);
        }
    }

    public virtual void OnDestroyOther(Ship _other) {}
}
