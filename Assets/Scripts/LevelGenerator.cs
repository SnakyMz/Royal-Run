using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    List<GameObject> chunks = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnChunks();
    }

    // Update is called once per frame
    void Update()
    {
        MoveChunks();
    }

    void SpawnChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            Vector3 chunkPosition = new Vector3(transform.position.x, transform.position.y, i * chunkLength);
            GameObject chunk = Instantiate(chunkPrefab, chunkPosition, Quaternion.identity, chunkParent);
            chunks[i] = chunk;
        }
    }

    void MoveChunks()
    {
        for ( int i = 0; i < chunks.Count; i++)
        {
            chunks[i].transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));
        }
    }
}
