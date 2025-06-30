using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject blackHolePrefab;
    public float hazardDelay = 10f;
    private bool hazardSpawned = false;

    void Update()
    {
        if (!hazardSpawned && Time.timeSinceLevelLoad > hazardDelay)
        {
            SpawnBlackHole(); // switch this based on type
            hazardSpawned = true;
        }
    }

    void SpawnBlackHole()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0); // adjust as needed
        Instantiate(blackHolePrefab, spawnPos, Quaternion.identity);
    }
}
