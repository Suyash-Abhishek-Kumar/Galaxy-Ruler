using UnityEngine;

public class MeteorHazard : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnInterval = 0.8f;
    public int totalMeteors = 10;
    public float xRange = 8f;
    public float spawnHeight = 6f;

    private float timer = 0f;
    private int spawnedCount = 0;

    void Update()
    {
        if (spawnedCount >= totalMeteors) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnMeteor();
        }
    }

    void SpawnMeteor()
    {
        float x = Random.Range(-xRange, xRange);
        Vector3 spawnPos = new Vector3(x, spawnHeight, 0f);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
        spawnedCount++;
    }
}
