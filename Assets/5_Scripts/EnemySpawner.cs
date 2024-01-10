using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public int spawncount;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public int enemyCount; //this one Chief
        public int spawnCount;
        public GameObject enemyPrefab;
    }

    public List<Wave> waves;
    public int currentWaveCount;
    public float spawnInterval;
    public List<GameObject> pooledEnemies;
    GameObject tmp;

    [Header("Spawner Attributes")]
    float spawnTimer;
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false;
    public float waveInterval;

    [Header("Spawn positions")]
    public List<Transform> relativeSpawnPoints;

    public static EnemySpawner SharedInstance;

    Transform player;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            //pooledEnemies = new List<GameObject>();
            
            for (int i = 0; i < enemyGroup.enemyCount; i++)
            {
                tmp = Instantiate(enemyGroup.enemyPrefab);
                tmp.SetActive(false);
                pooledEnemies.Add(tmp);
            }
        }
        player = FindObjectOfType<Player_Movement>().transform;
        enemiesAlive = 0;
        StartCoroutine(BeginNextWave());
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWaveCount < waves.Count && waves [currentWaveCount].spawncount == 0)
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
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
        Debug.Log(currentWaveQuota);
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

                    tmp = EnemySpawner.SharedInstance.GetPooledObject();
                    Debug.Log(tmp); 
                    if (tmp != null)
                    {
                        tmp.SetActive(true);
                        tmp.transform.position = player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position;                       
                    }
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

    public GameObject GetPooledObject()
    {
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            for (int i = 0; i < enemyGroup.enemyCount; i++)
            {
                if (!pooledEnemies[i].activeInHierarchy)
                {
                    return pooledEnemies[i];
                }
            }
            return null;
        }
        return null;
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }
}
