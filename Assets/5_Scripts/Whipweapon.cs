
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class Whipweapon : WeaponManagement.weapon
{
    public GameObject player;
    public float level2damage = 50;
    public float level3damage = 75;
    bool leveledup = false;
    int direction = 1;
    public Whipweapon(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2) : base(WeaponId2, Weaponname2, swingtime2, thisWeapon2, damage2, attackCooldown2)
    {
        



    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {

        if (enemy.gameObject.tag == "Enemy")
        {
            DoDamage(enemy.gameObject, this.damage);
        }
    }

    private void Start()
    {
        direction = 1;
    }

    private void OnEnable()

    {

        if (this.level == 2)
        {
            this.damage = level2damage;
        }
        if (this.level == 3)
        {
            this.damage = level3damage;

            if (!leveledup)
            {
                attackCooldown = attackCooldown / 2;
                leveledup = true;            }

        }
        this.transform.position = player.transform.position + new Vector3(this.transform.localScale.x/2,0,0);
        this.transform.localScale = new Vector3(Mathf.Sign(player.transform.localScale.x), 1, 1)*direction;
        if (leveledup) direction = -direction ;
    }

    private void Update()
    {
        this.transform.position = player.transform.position + new Vector3(this.transform.localScale.x / 2, 0, 0);
    }
}