using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class AlienGun : WeaponManagement.weapon
{
    public Rigidbody2D player;
    public List<GameObject>  bullets;
    public GameObject bullet;   
    public int bulletCount;
    public float bulletSpeed;
    public int bulletId;
    public AudioSource bulletsound;
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
        this.attackCooldown -= this.swingtime;
    }
    float RandomPitch(float min, float max)
    {
        float z = Random.value;
        if (z > min && z < max)
        {
            return z;
        }
        else return RandomPitch(min, max);
    }
    public void Shoot(int direction)
    {
        if (bulletId < bullets.Count -1)
        {

            bulletId++;
        }
        else
        {
            bulletId = 0;

        }
        GameObject ree = bullets[bulletId];
        ree.transform.position = this.transform.position;
        ree.SetActive(true);
        //bulletsound.pitch = Random.Range(-3,3);
        bulletsound.pitch = RandomPitch(0.7f,1.2f);
        bulletsound.Play();
        ree.GetComponent<Bullet>().lifetime = this.bulletlifetime;
        ree.GetComponent<Rigidbody2D>().velocity = ((new Vector2(1, 0) * Mathf.Sign(player.transform.localScale.x)) + player.velocity.normalized).normalized * this.bulletSpeed * direction;
        ree.GetComponent<Bullet>().damage = this.damage;
    }
    private void OnEnable()

    {
        if (this.level > 1)
        {
            this.damage = 50;

        }
        this.transform.position = player.transform.position;
        
        
        Shoot(1);

        if (this.level == 3)
        {
            Shoot(-1);
        }
        }
}