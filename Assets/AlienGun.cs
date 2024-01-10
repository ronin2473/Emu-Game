using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class AlienGun : WeaponManagement.weapon
{
    public GameObject player;
    public List<GameObject>  bullets;
    public GameObject bullet;   
    public int bulletCount;
    public float bulletSpeed;
    public int bulletId;
    [Range(0f, 10f)] public float bulletlifetime= 5;
    public AlienGun(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2) : base(WeaponId2, Weaponname2, swingtime2, thisWeapon2, damage2, attackCooldown2)
    {
        
    }

    public void Start()
    {
        for (int i = 0; i < bulletCount;i++)
        {
            GameObject tmp = Instantiate(bullet);
            this.bullets.Add(tmp);
            tmp.GetComponent<Bullet>().damage = this.damage;
            tmp.GetComponent<Bullet>().lifetime = this.bulletlifetime;
            tmp.SetActive(false);
        }   
    }
    private void OnEnable()

    {
        this.transform.position = player.transform.position;
        GameObject ree;
        if (bulletId < bullets.Count) {
            ree = bullets[bulletId];
            ree.transform.position = this.transform.position;
            ree.SetActive(true);
            ree.GetComponent<Rigidbody2D>().velocity = ((new Vector2(1, 0) * Mathf.Sign(player.transform.localScale.x)) + player.GetComponent<Rigidbody2D>().velocity.normalized).normalized * this.bulletSpeed;
            bulletId++;
        }
        else
        {
            bulletId = 0;
            ree = bullets[bulletId];
            ree.transform.position = this.transform.position;
            ree.SetActive(true);
            ree.GetComponent<Bullet>().lifetime = this.bulletlifetime;
            ree.GetComponent<Rigidbody2D>().velocity = ((new Vector2(1,0)*Mathf.Sign(player.transform.localScale.x)) + player.GetComponent<Rigidbody2D>().velocity.normalized).normalized * this.bulletSpeed;
            
        }
        }
}