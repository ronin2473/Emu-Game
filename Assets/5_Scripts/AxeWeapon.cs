using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : WeaponManagement.weapon
{
    public Rigidbody2D player;
    public List<Axe> axes;
    public Axe axe;
    public int axeCount;
    public float axeSpeed;
    public int axeId = 0;
    public AudioSource axeSound;
    [Range(0f, 10f)] public float axeFlightDuration = 5;
    public AxeWeapon(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2) : base(WeaponId2, Weaponname2, swingtime2, thisWeapon2, damage2, attackCooldown2)
    {

    }

    public void Start()
    {
        this.attackCooldown -= swingtime;
        for (int i = 0; i < axeCount ; i++)
        {
            Axe tmp = Instantiate(axe);
            tmp.damage = damage;
            tmp.lifetime = axeFlightDuration;
            tmp.audio = axeSound;
            axes.Add(tmp);
            tmp.thisaxe.SetActive(false);

        }
        

    }


    

    public void Shoot(int direction)
    {

        if (axes.Count != 0)
        {
            if (axeId >= axes.Count)
            {
                axeId = 0;

            }
            Debug.Log(axes.Count);
            Axe ree = axes[axeId];
            ree.axerigi.transform.position = this.transform.position;
            ree.axerigi.gameObject.SetActive(true);
            //bulletsound.pitch = Random.Range(-3,3);
            //axeSound.Play();

            ree.lifetime = this.axeFlightDuration;

            ree.axerigi.AddForce((new Vector2(100 * Mathf.Sign(player.transform.localScale.x) + 100 * player.velocity.x, 250 + 100 * player.velocity.y) * axeSpeed));

            ree.damage = this.damage;
            ree.audio.Play();
            axeId++;
        }
    }
    private void OnEnable()

    {
        
        if (this.level > 1)
        {
            if (level == 2) damage = 30;
            if (level == 3) damage = 40;
            attackCooldown = 1.5f;

        }
        this.transform.position = player.transform.position;


        Shoot(1);

        if (this.level == 3)
        {
            Shoot(-1);
        }
    }
}
