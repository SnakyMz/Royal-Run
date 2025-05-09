using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);
        List<int> availableLanes = new List<int> { 0, 1, 2 };

        for (int i = 0; i < fencesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomIndex];
            availableLanes.RemoveAt(randomIndex);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
