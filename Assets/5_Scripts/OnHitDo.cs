using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDo : MonoBehaviour
{
    [SerializeField] TestWeaponBehaviour weaponManager;
    private void OnTriggerStay2D(Collider2D enemy)
    {


        if (enemy.gameObject.tag == "Enemy")
        {
            EnemyStats stats = enemy.GetComponent<EnemyStats>();
            stats.takedamage(25,weaponManager.weaponSwingTime);
        }
    }
}
