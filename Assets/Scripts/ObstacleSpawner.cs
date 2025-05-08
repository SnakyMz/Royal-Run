using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    void Start()
    {
        int spawnAmount = 0;

        while (spawnAmount < 5)
        {
            StartCoroutine(SpawnObstacle());
            spawnAmount++;
        }
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
