using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    
    public int maxHealth;
    public int currentHealth;
    public int charid = CharController.choosenChar;
    public HealthBar healthBar;
    public bool isdead = false;
    public GameObject weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        Emu.ChoosenEmu charc = Emu.emus[charid];
        maxHealth = charc.maxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) { 
        
            this.GetComponent<Player_Movement>().speed = 0;
            isdead = true;
            weaponManager.SetActive(false); 
            this.GetComponent<Rigidbody2D>().mass = 9999999999;
            GetComponentInChildren<Animator>().SetBool("IsDead?", true);

        }
        healthBar.SetHealth(currentHealth);
    }
}
