using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]  float currentHealth = 50;
    float waitedtime = 0.5f;

    public float despawnDistance = 20f;
    Transform player;

    void Start()
    {
        player = FindObjectOfType<Player_Movement>().transform;
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
        waitedtime += Time.deltaTime;
        if (waitedtime > 0.5f) { 
            waitedtime= 0;
            currentHealth -= amount;
            if (currentHealth <= 0) {

                //this.gameObject.SetActive(false);
                Destroy(gameObject);
            
            }
        }
    }

    private void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnEnemyKilled();
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
}

