using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerNoPooling : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public float spawnInterval;
        public int spawncount;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefab;
    }

    public List<Wave> waves;
    public int currentWaveCount;

    [Header("Spawner Attributes")]
    float spawnTimer;
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false;
    public float waveInterval;
    public HasItems itemsystem;

    [Header("Spawn positions")]
    public List<Transform> relativeSpawnPoints;

    Transform player;
    public int enemiesdied = 0;
    public string win;
    public TextMeshProUGUI wavecompletetext;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Movement>().transform;
        CalculateWaveQuota();
        wavecompletetext.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentWaveCount < waves.Count -1 && waves[currentWaveCount].spawncount == 0 )
        //Debug.Log(enemiesdied);
        if (currentWaveCount < waves.Count - 1 && enemiesdied == waves[currentWaveCount].waveQuota)
        {
            
            //Debug.Log("test");
            enemiesdied = 0;
            StartCoroutine(BeginNextWave());
        }
        if(currentWaveCount == waves.Count - 1 && enemiesdied == waves[currentWaveCount].waveQuota)
            {
            SceneManager.LoadScene(win);
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();

        }
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;

            //level up stuff
            itemsystem.LevelUp();
            wavecompletetext.gameObject.SetActive(true);
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var EnemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += EnemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        //Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies()
    {
        if (waves[currentWaveCount].spawncount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawncount++;
                    enemiesAlive++;
                }
            }
        }

        if (enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
        enemiesdied++;
    }
}
