using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform obstacleParent;
    [Header("Spawn Settings")]
    [SerializeField] float obstacleSpawnedTime = 3f;
    [SerializeField] float spawnRange = 4f;
    [SerializeField] float minSpawnTime = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {   
        while (true)
        {
            yield return new WaitForSeconds(obstacleSpawnedTime);

            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, transform.position.z);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
        }
    }

    public void DecreaseObstacleSpawnTime(float amount)
    {
        if (obstacleSpawnedTime > minSpawnTime)
        {
            obstacleSpawnedTime -= amount;
        }
    }
}
