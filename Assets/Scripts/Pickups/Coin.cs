using UnityEngine;

public class Coin : Pickup
{
    [Header("Coin Settings")]
    [SerializeField] int points = 100;

    Scoreboard scoreboard;

    public void Init(Scoreboard scoreB)
    {
        scoreboard = scoreB;
    }
    protected override void OnPickup()
    {
        scoreboard.IncreaseScore(points);
    }
}
