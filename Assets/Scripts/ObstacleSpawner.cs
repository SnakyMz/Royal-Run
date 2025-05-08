using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float obstacleSpawnedTime = 1f;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {   
        while (true)
        {
            yield return new WaitForSeconds(obstacleSpawnedTime);
            
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
        }
    }
}
