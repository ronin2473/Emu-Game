
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ankhstaff : WeaponManagement.weapon
{
    public GameObject player;
    public AudioSource ankhstaffSound;
    public float level2damage = 50;
    public float level3damage = 75;
    bool played = false;
    public Ankhstaff(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2) : base(WeaponId2, Weaponname2, swingtime2, thisWeapon2, damage2, attackCooldown2)
    {
        this.WeaponId = WeaponId2;
        this.Weaponname = Weaponname2;
        this.swingtime = swingtime2;
        this.attackTime = 0;
        this.damage = damage2;
        this.attackCooldown = attackCooldown2;



    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {

        if (enemy.gameObject.tag == "Enemy")
        {
            DoDamage(enemy.gameObject, this.damage);
        }
    }


    private void OnEnable()

    {
        if (played)
        {
            ankhstaffSound.Play();
        }
        played = true;
        if (this.level == 2)
        {
            this.damage = level2damage;
        }
        if (this.level == 3)
        {
            this.damage = level3damage;
        }
        this.transform.position = player.transform.position;
        this.transform.localScale = new Vector3(Mathf.Sign(player.transform.localScale.x), 1, 1);
    }

    private void Update()
    {
        this.transform.position = player.transform.position;
    }
}






