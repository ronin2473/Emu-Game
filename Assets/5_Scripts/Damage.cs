using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    private float time;
    [SerializeField] private float waittill;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && (time += Time.deltaTime) >= waittill)
        {
            time = 0;
            var health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(1);

        }
    }
}
