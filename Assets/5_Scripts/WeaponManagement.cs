using System;
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
        public int level = 0;
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
    public int charid;
    public weapon[] weapons;
    [SerializeField] public GameObject player;

    void Start()
    {
        charid = CharController.choosenChar;
        Emu.ChoosenEmu charc = Emu.emus[charid];

        foreach (weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);

            
            //if (charc != null)
            //{
            //    if (charc.startWeapon == weapon.WeaponId)
            //    {
            //        weapon.isActive = true;

            //    }
            //}
            //else
            //{
            //    weapons[0].isActive = true;
            //    weapons[0].level = 1;
            //}

        }
        
        
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
