using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    { 
        currentHealth -= damageAmount;
        if (currentHealth <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
