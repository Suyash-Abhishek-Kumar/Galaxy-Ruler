using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyWave
    {
        public GameObject enemyPrefab;
        public int count;
        public float spawnInterval;
    }

    public EnemyWave[] waves;
    public Transform[] spawnPoints;

    private int currentWave = 0;
    private int spawned = 0;
    private float timer = 0f;
    private bool spawningStarted = false;

    public GameObject meteorHazardPrefab;
    public GameObject blackholehazardPrefab;         // Assign in inspector (BlackHole, Meteor, etc.)
    public float hazardDelay = -1f;    // Set in LevelSetup
    public bool hazardSpawned = true;     // Internal flag
    public string hazardToSpawn;


    public void BeginSpawning()
    {
        spawningStarted = true;
        currentWave = 0;
        spawned = 0;
    }

    void Update()
    {
        if (!hazardSpawned && blackholehazardPrefab != null && Time.timeSinceLevelLoad >= hazardDelay && hazardToSpawn == "blackhole")
        {
            SpawnBlackHole();
            hazardSpawned = true;
        }
        if (!hazardSpawned && meteorHazardPrefab != null && Time.timeSinceLevelLoad >= hazardDelay && hazardToSpawn == "meteorshower")
        {
            Instantiate(meteorHazardPrefab, Vector3.zero, Quaternion.identity); // or offscreen
            hazardSpawned = true;
        }

        if (!spawningStarted || currentWave >= waves.Length)
            {
                // Check if all enemies are dead
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    SceneLoader.Instance.LoadGameWin();
                }
                return;
            }

        EnemyWave wave = waves[currentWave];

        timer += Time.deltaTime;

        if (spawned < wave.count && timer >= wave.spawnInterval)
        {
            SpawnEnemy(wave.enemyPrefab);
            spawned++;
            timer = 0f;
        }

        if (spawned >= wave.count && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            currentWave++;
            spawned = 0;
            timer = 0f;
        }
    }
    void SpawnBlackHole()
    {
        Vector3 spawnPos = Vector3.zero; // adjust position if needed
        Instantiate(blackholehazardPrefab, spawnPos, Quaternion.identity);
    }


    void SpawnEnemy(GameObject enemyPrefab)
    {
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
