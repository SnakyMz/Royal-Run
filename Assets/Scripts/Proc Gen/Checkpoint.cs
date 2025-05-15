using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float timeBonus = 5f;
    [SerializeField] float decreaseSpawnTime = 0.2f;

    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    const string playerTag = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            gameManager.IncreaseTime(timeBonus);
            obstacleSpawner.DecreaseObstacleSpawnTime(decreaseSpawnTime);
        }
    }
}
