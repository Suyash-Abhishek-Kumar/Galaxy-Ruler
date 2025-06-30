using System.Collections.Generic;
using UnityEngine;
using static EnemySpawner;

public class LevelSetup : MonoBehaviour
{
    public EnemySpawner spawner;

    [Header("Enemy Prefabs")]
    public GameObject lamiaPrefab;
    public GameObject maraPrefab;
    public GameObject ahrimanPrefab;
    public GameObject typhonPrefab;
    public GameObject lokiPrefab;
    public GameObject kaliPrefab;

    void Start()
    {
        int level = LevelManager.Instance.GetLevel();

        switch (level)
        {
            case 1: SetupLevel1(); break;
            case 2: SetupLevel2(); break;
            case 3: SetupLevel3(); break;
            case 4: SetupLevel4(); break;
            case 5: SetupLevel5(); break;
            case 6: SetupLevel6(); break;
            case 7: SetupLevel7(); break;
            case 8: SetupLevel8(); break;
            //case 9: SetupLevel9(); break;
            //case 10: SetupLevel10(); break;
            default: SetupLevel1(); break;
        }
        spawner.BeginSpawning();
    }

    void SetupLevel1()
    {
        spawner.waves = new List<EnemyWave>
        {
            new EnemyWave { enemyPrefab = lamiaPrefab, count = 5, spawnInterval = 2f },
            new EnemyWave { enemyPrefab = lamiaPrefab, count = 6, spawnInterval = 2f },
            new EnemyWave { enemyPrefab = maraPrefab, count = 4, spawnInterval = 2f },
        }.ToArray();
    }

    void SetupLevel2()
    {
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 5, spawnInterval = 1.8f },
        new EnemyWave { enemyPrefab = maraPrefab, count = 6, spawnInterval = 1.8f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 4, spawnInterval = 1.8f },
    }.ToArray();
    }

    void SetupLevel3()
    {
        spawner.hazardToSpawn = "meteorshower"; // new field
        spawner.hazardDelay = 1f; // seconds after wave start
        spawner.hazardSpawned = false;
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 4, spawnInterval = 1.7f },
        new EnemyWave { enemyPrefab = maraPrefab, count = 6, spawnInterval = 1.7f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 5, spawnInterval = 1.7f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 2, spawnInterval = 1.7f },
    }.ToArray();
    }

    void SetupLevel4()
    {
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 5, spawnInterval = 1.6f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 3, spawnInterval = 1.6f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 6, spawnInterval = 1.6f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 4, spawnInterval = 1.6f },
    }.ToArray();
    }

    void SetupLevel5()
    {
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 4, spawnInterval = 1.5f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 6, spawnInterval = 1.5f },
        new EnemyWave { enemyPrefab = lokiPrefab, count = 1, spawnInterval = 1.5f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 3, spawnInterval = 1.5f },
        new EnemyWave { enemyPrefab = lokiPrefab, count = 2, spawnInterval = 1.5f },
    }.ToArray();
    }

    void SetupLevel6()
    {
        spawner.hazardToSpawn = "blackhole"; // new field
        spawner.hazardDelay = 1f; // seconds after wave start
        spawner.hazardSpawned = false;
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 5, spawnInterval = 1.4f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 4, spawnInterval = 1.4f },
        new EnemyWave { enemyPrefab = maraPrefab, count = 6, spawnInterval = 1.4f },
        new EnemyWave { enemyPrefab = lokiPrefab, count = 2, spawnInterval = 1.4f },
        // new EnemyWave { enemyPrefab = kaliPrefab, count = 1, spawnInterval = 1.4f },
    }.ToArray();
    }

    void SetupLevel7()
    {
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = maraPrefab, count = 4, spawnInterval = 1.3f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 5, spawnInterval = 1.3f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 4, spawnInterval = 1.3f },
        new EnemyWave { enemyPrefab = lokiPrefab, count = 2, spawnInterval = 1.3f },
        new EnemyWave { enemyPrefab = kaliPrefab, count = 1, spawnInterval = 1.3f },
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 5, spawnInterval = 1.3f },
    }.ToArray();
    }

    void SetupLevel8()
    {
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = typhonPrefab, count = 5, spawnInterval = 1.2f },
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 4, spawnInterval = 1.2f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 6, spawnInterval = 1.2f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 3, spawnInterval = 1.2f },
        new EnemyWave { enemyPrefab = lokiPrefab, count = 3, spawnInterval = 1.2f },
        new EnemyWave { enemyPrefab = kaliPrefab, count = 1, spawnInterval = 1.2f },
    }.ToArray();
    }

    /*void SetupLevel9()
    {
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 6, spawnInterval = 1.1f },
        new EnemyWave { enemyPrefab = maraPrefab, count = 6, spawnInterval = 1.1f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 6, spawnInterval = 1.1f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 4, spawnInterval = 1.1f },
        new EnemyWave { enemyPrefab = lokiPrefab, count = 3, spawnInterval = 1.1f },
        new EnemyWave { enemyPrefab = kaliPrefab, count = 2, spawnInterval = 1.1f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 6, spawnInterval = 1.1f },
    }.ToArray();
    }

    void SetupLevel10()
    {
        spawner.waves = new List<EnemyWave>
    {
        new EnemyWave { enemyPrefab = lamiaPrefab, count = 5, spawnInterval = 1f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 5, spawnInterval = 1f },
        new EnemyWave { enemyPrefab = lokiPrefab, count = 4, spawnInterval = 1f },
        new EnemyWave { enemyPrefab = kaliPrefab, count = 1, spawnInterval = 1f },
        new EnemyWave { enemyPrefab = typhonPrefab, count = 6, spawnInterval = 1f },
        new EnemyWave { enemyPrefab = lokiPrefab, count = 3, spawnInterval = 1f },
        new EnemyWave { enemyPrefab = ahrimanPrefab, count = 6, spawnInterval = 1f },
        new EnemyWave { enemyPrefab = kaliPrefab, count = 2, spawnInterval = 1f },
    }.ToArray();
    }*/
}
