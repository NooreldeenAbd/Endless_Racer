using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private List<int> spawnList = new List<int>();
    private float timeToSpawn = 2f;
    private float timeBetweenSpawns = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenSpawns;
        }
    }

    private void SpawnBlocks()
    {
        RandomizeSpawnPoints();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnList.Contains(i))
            {
                Instantiate(enemyPrefabs[0], spawnPoints[i].position, Quaternion.identity);
            }
        }
    }

    private void RandomizeSpawnPoints()
    {
        int rand = Random.Range(1, spawnPoints.Length);
        spawnList.Clear();

        for (int i = 0; i <= rand; i++)
        {
            spawnList.Add(Random.Range(0, spawnPoints.Length));
        }
    }
}
