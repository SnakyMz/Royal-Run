using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            Vector3 chunkPosition = new Vector3(transform.position.x, transform.position.y, i * chunkLength);
            Instantiate(chunkPrefab, chunkPosition, Quaternion.identity, chunkParent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
