using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDo : MonoBehaviour
{
    [SerializeField] public float swingtime;
    public float dmg;
    private void OnTriggerStay2D(Collider2D enemy)
    {

        if (enemy.gameObject.tag == "Enemy")
        {
            EnemyStats stats = enemy.GetComponent<EnemyStats>();
            stats.takedamage(dmg);
            this.gameObject.SetActive(false);
        }
    }
}
