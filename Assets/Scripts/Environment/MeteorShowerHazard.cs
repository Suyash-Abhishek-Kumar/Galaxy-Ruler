using UnityEngine;
using System.Collections;

public class MeteorShowerHazard : MonoBehaviour
{
    public GameObject meteorPrefab;

    public int meteorCount = 6;
    public float spacing = 1.5f;
    public float yCenter = 0f;
    public float startX = -10f;
    public Vector2 direction = Vector2.right;

    public int totalRounds = 3;
    public float delayBeforeStart = 1f;
    public float delayBetweenRounds = 3f;

    private void Start()
    {
        StartCoroutine(StartMeteorRounds());
    }

    IEnumerator StartMeteorRounds()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        for (int round = 0; round < totalRounds; round++)
        {
            SpawnShower();
            yield return new WaitForSeconds(delayBetweenRounds);
        }

        Destroy(gameObject); // Remove spawner after it's done
    }

    void SpawnShower()
    {
        float totalHeight = spacing * (meteorCount - 1);
        float startY = yCenter - totalHeight / 2f;

        for (int i = 0; i < meteorCount; i++)
        {
            Vector3 spawnPos = new Vector3(startX - Random.Range(0, 10) * 10, startY + Random.Range(5, i*10) * 0.1f * spacing, 0f);
            GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

            Meteor meteorScript = meteor.GetComponent<Meteor>();
            if (meteorScript != null)
                meteorScript.direction = direction;
        }
    }
}
