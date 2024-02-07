using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource audioSource1;
    AudioSource audioSource2;
    [SerializeField]  float currentHealth = 50;
    public float speed;
    bool dead = false;

    public float despawnDistance = 20f;
    Transform player;

    void Start()
    {
        var tmp = FindObjectOfType<Player_Movement>();
        player = tmp.transform;
        audioSource1 = tmp.audioSource1;
        audioSource2 = tmp.audioSource2;

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
        }
        audioSource.Play();
            currentHealth -= amount;
            if (currentHealth <= 0 && !dead) {
                dead = true;
                EnemySpawnerNoPooling es = FindObjectOfType<EnemySpawnerNoPooling>();
                es.OnEnemyKilled();
                Destroy(this.gameObject);
                //OnDisable();
                //Destroy(gameObject);

            }
        
    }

    //void OnDisable()
    //{
    //    EnemySpawner es = FindObjectOfType<EnemySpawner>();
    //    es.OnEnemyKilled();
    //}

    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
}

