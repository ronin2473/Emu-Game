using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    [System.Serializable]
    public class weapon : MonoBehaviour
    {
        public int WeaponId;
        public string Weaponname;
        public float swingtime;
        public GameObject thisWeapon;
        public float damage;
        public bool isActive = false;
        public float attackCooldown;
        public float attackTime = 0;

        public weapon(int WeaponId2, string Weaponname2, float swingtime2, GameObject thisWeapon2, float damage2, float attackCooldown2)
        {
            WeaponId = WeaponId2;
            Weaponname = Weaponname2;
            swingtime = swingtime2;
            thisWeapon = thisWeapon2;
            damage = damage2;
            attackCooldown = attackCooldown2;
        }
        public void DoDamage(GameObject enemy, float damage)
        {
            EnemyStats stats = enemy.GetComponent<EnemyStats>();
            stats.takedamage(damage);

        }

        



    }

    public weapon[] weapons;
    [SerializeField] public GameObject player;
    public float weaponSwingTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        weapons[0].thisWeapon.SetActive(false);
    }

    void Update()
    {
        foreach (weapon weapon in weapons)
        {
            if (weapon.thisWeapon.activeSelf == false)
                {
                weapon.attackTime += Time.deltaTime;
            }
            if (weapon.attackTime >= weapon.attackCooldown)
                {
                
                if (weapon.isActive)
                    {

                    SwingWeapon(weapon.swingtime, weapon.thisWeapon);
                    }
                weapon.attackTime = 0f;
            }

            
        }
        




    }
    void SwingWeapon(float time, GameObject weapon)
    {
        weapon.SetActive(true);
        StartCoroutine(EndOfSwing(time, weapon));

    }

    IEnumerator EndOfSwing(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        StopCoroutine("EndOfSwing");
    }
}
