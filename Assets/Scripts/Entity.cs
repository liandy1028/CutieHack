using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int val)
    {
        currentHealth -= val;
        if(currentHealth <= 0)
        {
            EntityDie();
        }
    }

    protected virtual void EntityDie()
    {
        print(gameObject + " Has died");
    }
}
