using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldinstance : MonoBehaviour
{
    public float damage;
    public Transform player;
    public float speed;
    private float angle;
    public float r;
    public AudioSource shieldaudio;

    
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void Randomr(float radius)
    {
        r = radius;
        this.transform.position = player.position + new Vector3(r, 0, 0);
    }
    public void Movearound()
    {
        float x = player.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * r;
        float y = player.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * r;
        // Set the new position of the rotating object
        transform.position = new Vector3(x, y, transform.position.z);

        // Update the angle based on rotation speed
        angle += speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            shieldaudio.Play();
            EnemyStats stats = collision.gameObject.GetComponent<EnemyStats>();
            stats.takedamage(damage);
        }
    }
}
