using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public AudioSource hurtsound;
    public int maxHealth;
    public int currentHealth;
    public int charid;
    public HealthBar healthBar;
    public bool isdead = false;
    public WeaponManagement weaponManager;
    public AudioSource dying;
    public AudioSource gameOver;
    AudioManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        charid = CharController.choosenChar;
        Emu.ChoosenEmu charc = Emu.emus[charid];
        if (charc != null)
        {
            maxHealth = charc.maxHealth;
        }
        else maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    public void TakeDamage(int damageAmount)
    {
        
        
        currentHealth -= damageAmount;
        if (currentHealth <= 0 && !isdead) { 
        
            this.GetComponent<Player_Movement>().speed = 0;
            isdead = true;
            
            if (manager != null)
            {
                manager.musicSource.Stop();
            }
            if (dying  != null) 
            {
                dying.Play();
            }
            
            
            foreach (WeaponManagement.weapon weapon in weaponManager.weapons)
            {
                weapon.isActive = false;
                weapon.gameObject.SetActive(false);
            }
            weaponManager.gameObject.SetActive(false); 
            this.GetComponent<Rigidbody2D>().mass = 9999999999;
            GetComponentInChildren<Animator>().SetBool("IsDead?", true);

        }
        if (!isdead)
        {
            hurtsound.Play();
        }
        healthBar.SetHealth(currentHealth);
    }

    
}
