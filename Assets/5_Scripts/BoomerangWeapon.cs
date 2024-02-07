using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangWeapon : WeaponManagement.weapon
{
    // Start is called before the first frame update
    public float speed;
    public float amplitude;
    public float level2damage;
    public float level3damage;
    public new Rigidbody2D rigidbody;
    public Transform player;
    public BoomerangWeapon(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2) : base(WeaponId2, Weaponname2, swingtime2, thisWeapon2, damage2, attackCooldown2) {
    

    }
    private float time;

    [System.Obsolete]
    void Update()
    {
        if (this.level == 2)
        {
            this.damage = level2damage;
        }
        if (this.level == 3)
        {
            this.damage = level3damage;

            

        }
        time += Time.deltaTime * speed;

        float x = amplitude * Mathf.Sin(time * 2);
        float y = amplitude * Mathf.Sin(2.5f * time);
        this.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + amplitude * Mathf.Sign(time));
        //this.transform.rotation.SetEulerRotation(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + amplitude * Mathf.Sign(time * 2));
        //this.transform.rotation.Set(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z +amplitude * Mathf.Sign(time * 2), this.transform.rotation.w);
        this.transform.position = (new Vector3(x, y, 0f)) + player.position;
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {

        if (enemy.gameObject.tag == "Enemy")
        {
            DoDamage(enemy.gameObject, this.damage);
        }
    }
}
