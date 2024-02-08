using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime;
    public float damage;
    public Animator animator;
    bool ree = true;

    private void OnEnable()
    {
        if (ree)
        {
            ree = false;
            animator.playbackTime = 0;
        }
        
        StartCoroutine("DisableObject");
    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(lifetime);
        this.gameObject.SetActive(false);
        StopCoroutine("DisableObject");
    }
    private void OnDisable()
    {
        StopCoroutine("DisableObject");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats stats = collision.gameObject.GetComponent<EnemyStats>();
            stats.takedamage(damage);
            this.gameObject.SetActive(false);
            animator.playbackTime = 0;
        }
    }
}
