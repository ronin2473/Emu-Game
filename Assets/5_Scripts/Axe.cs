using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float damage;
    public float lifetime;
    public Rigidbody2D axerigi;
    public GameObject thisaxe;
    public new AudioSource audio;
    private void OnEnable()
    {
        StartCoroutine("DisableObject");
        
    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(lifetime);
        audio.Stop();
        thisaxe.SetActive(false);
        StopCoroutine("DisableObject");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats stats = collision.gameObject.GetComponent<EnemyStats>();
            stats.takedamage(damage);
            thisaxe.SetActive(false);
        }
    }
}
