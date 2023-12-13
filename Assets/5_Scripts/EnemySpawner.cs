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
        public float spawnInterval;
        public int spawncount;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public  List<GameObject> pooledEnemies;
        public int enemyCount = 20; //this one Chief
        public int spawnCount;
        public GameObject enemyPrefab;
        //public EnemyGroup(int enemyCount1, int spawnCount1, GameObject enemyPrefab1, List<GameObject> pooledEnemies1)
        //{
        //      enemyCount1 = enemyCount;
        //      spawnCount1 = spawnCount;
        //      enemyPrefab1 = enemyPrefab;
        //      pooledEnemies1 = pooledEnemies;
        //}
    }

    public List<Wave> waves;
    public int currentWaveCount;

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
            enemyGroup.pooledEnemies = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < enemyGroup.enemyCount; i++)
            {
                tmp = Instantiate(enemyGroup.enemyPrefab);
                tmp.SetActive(false);
                enemyGroup.pooledEnemies.Add(tmp);
            }
        }
        player = FindObjectOfType<Player_Movement>().transform;
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWaveCount < waves.Count && waves [currentWaveCount].spawncount == 0)
        {
            StartCoroutine(BeginNextWave());
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
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var EnemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveCount += EnemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
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

                    GameObject enemy = EnemySpawner.SharedInstance.GetPooledObject(); //player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);
                    if (enemy != null)
                    {
                        enemy.transform.position = player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position;
                        enemy.SetActive(true);
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
                if (!enemyGroup.pooledEnemies[i].activeInHierarchy)
                {
                    return enemyGroup.pooledEnemies[i];
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
