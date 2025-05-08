using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float obstacleSpawnedTime = 1f;

    int spawnAmount = 0;
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {   
        while (spawnAmount < 5)
        {
            yield return new WaitForSeconds(obstacleSpawnedTime);
            
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            spawnAmount++;
        }
    }
}
