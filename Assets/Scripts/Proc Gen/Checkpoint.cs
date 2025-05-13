using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float timeBonus = 5f;

    GameManager gameManager;

    const string playerTag = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            gameManager.IncreaseTime(timeBonus);
        }
    }
}
