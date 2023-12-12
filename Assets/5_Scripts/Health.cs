using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField] string deathscene;
    public int maxHealth;
    public int currentHealth;
    public int charid = CharController.choosenChar;
    public HealthBar healthBar;
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
        if (currentHealth <= 0)
        {
            //this.gameObject.SetActive(false);
            // start death animation
            SceneManager.LoadScene(deathscene);
        }
        healthBar.SetHealth(currentHealth);
    }
}
