using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]  float currentHealth = 50;
    float waitedtime = 0.5f;
    public void takedamage(float amount)
    {
        waitedtime += Time.deltaTime;
        if (waitedtime > 0.5f) { 
            waitedtime= 0;
            currentHealth -= amount;
            if (currentHealth <= 0) {
                
                this.gameObject.SetActive(false);
            
            }
        }
    }
}
