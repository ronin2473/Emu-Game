
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;

public class ScreamAttack : WeaponManagement.weapon
{
    public GameObject player;
    public Rigidbody2D playerrigi;
    public AudioSource attackSound;
    public float level2damage = 30;
    public float level3damage = 40;
    public Rigidbody2D rigi;
    public float wavespeed = 2f;
    public Vector3 gettiingbigger;
    bool played = false;
    public ScreamAttack(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2) : base(WeaponId2, Weaponname2, swingtime2, thisWeapon2, damage2, attackCooldown2)
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
            attackSound.Play();
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
        rigi.velocity = ((new Vector2(1, 0) * Mathf.Sign(player.transform.localScale.x))* this.wavespeed + playerrigi.velocity.normalized).normalized * this.wavespeed;
    }

    private void Update()
    {
        this.transform.localScale += gettiingbigger;
        
    }
}






