using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    private float time;
    [SerializeField] private float waittill;

    private void Start()
    {
        time = waittill;
    }
    private void Update()
    {
        time += Time.deltaTime;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && time >= waittill)
        {
            time = 0;
            var health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(50);

        }
    }
}
