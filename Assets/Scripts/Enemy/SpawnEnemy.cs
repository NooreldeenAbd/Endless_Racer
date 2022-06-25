using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spwanPoints;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

    }
}
