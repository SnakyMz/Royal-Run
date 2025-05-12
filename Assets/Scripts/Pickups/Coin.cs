using UnityEngine;

public class Coin : Pickup
{
    [Header("Coin Settings")]
    [SerializeField] int points = 100;

    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    protected override void OnPickup()
    {
        scoreboard.IncreaseScore(points);
    }
}
