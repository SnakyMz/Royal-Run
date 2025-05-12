using UnityEngine;

public class Apple : Pickup
{
    [Header("Apple Settings")]
    [SerializeField] float increaseChunkSpeed = 3f;

    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGen)
    {
        levelGenerator = levelGen;
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkSpeed(increaseChunkSpeed);
    }
}
