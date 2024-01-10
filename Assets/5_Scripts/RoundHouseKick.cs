using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundHouseKick : WeaponManagement.weapon
{
    public GameObject player;

    public RoundHouseKick(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2) : base(WeaponId2, Weaponname2, swingtime2,  thisWeapon2, damage2, attackCooldown2)
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
                DoDamage(enemy.gameObject,this.damage);
        }
    }
    public void Start()
    {
        this.thisWeapon = this.gameObject;
        this.attackCooldown += this.swingtime;
    }

    private void OnEnable()
    
    {
        this.transform.position = player.transform.position;
    }

    private void Update()
    {
        this.transform.position = player.transform.position;
    }
}





