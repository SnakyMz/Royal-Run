using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    [Header("Level Settings")]
    [SerializeField] int startingChunksAmount = 12;
    [Tooltip("Dont chnange, the value must be same as the chunk prefab length")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravityZ = -22f;
    [SerializeField] float maxGravityZ = -2f;

    List<GameObject> chunks = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnStartingChunks();
    }

    // Update is called once per frame
    void Update()
    {
        MoveChunks();
    }

    public void ChangeChunkSpeed(float speedAmount)
    {
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravityZ, maxGravityZ);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);

            cameraController.ChangeFOV(speedAmount);
        }

    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        Vector3 chunkPosition = new Vector3(transform.position.x, transform.position.y, (chunks.Count * chunkLength) - chunkLength);
        GameObject chunk = Instantiate(chunkPrefab, chunkPosition, Quaternion.identity, chunkParent);
        chunks.Add(chunk);
    }

    void MoveChunks()
    {
        for ( int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));
            
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
