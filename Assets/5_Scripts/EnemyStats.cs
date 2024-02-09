using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource audioSource1;
    AudioSource audioSource2;
    AudioSource audioSource3;
    SpriteRenderer sprite;
    [SerializeField]  float currentHealth = 50;
    public float speed;
    bool dead = false;
    bool collered= false;

    public float despawnDistance = 20f;
    Transform player;

    void Start()
    {
        var tmp = FindObjectOfType<Player_Movement>();
        player = tmp.transform;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), tmp.edgemap);
        audioSource1 = tmp.audioSource1;
        audioSource2 = tmp.audioSource2;
        audioSource3 = tmp.audioSource3;
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance) 
        {
            ReturnEnemy();
        }

    }
    public void takedamage(float amount)
    {
        if (audioSource1 != null)
        {
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                audioSource = audioSource1;
                
            }
            else if (audioSource2 != null)
            {
                
                audioSource = audioSource2;
            }
            else
            {
                audioSource = audioSource1;
            }
            if (!collered) { 
                collered = true;
            Color col = sprite.color;
            sprite.color = Color.red;
            StartCoroutine(blink(0.2f, sprite,col));
            }

        }
        
            currentHealth -= amount;
            if (currentHealth <= 0 && !dead) {
                dead = true;
                EnemySpawnerNoPooling es = FindObjectOfType<EnemySpawnerNoPooling>();
                es.OnEnemyKilled();
            audioSource = audioSource3;
                Destroy(this.gameObject);
                //OnDisable();
                //Destroy(gameObject);

            }
        audioSource.Play();

    }

    //void OnDisable()
    //{
    //    EnemySpawner es = FindObjectOfType<EnemySpawner>();
    //    es.OnEnemyKilled();
    //}
    
    IEnumerator blink(float time,SpriteRenderer sprite,Color color)
    {
        yield return new WaitForSeconds(time);
        sprite.color = color;
        collered = false;
    }
    
    void ReturnEnemy()
    {
        EnemySpawnerNoPooling es = FindObjectOfType<EnemySpawnerNoPooling>();
        es.resettimer += Time.deltaTime;
        if (es.resettimer >= 0.5f) { 
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
        } 
        
    }
}

