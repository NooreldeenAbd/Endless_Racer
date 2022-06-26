using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spwanPoints;
    public GameObject enemyPrefab;
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
        int rand = Random.Range(0, spwanPoints.Length);
        for (int i = 0; i < spwanPoints.Length; i++)
        {
            if (rand != i)
            {
                Instantiate(enemyPrefab, spwanPoints[i].position, Quaternion.identity);
            }
        }
    }
}
