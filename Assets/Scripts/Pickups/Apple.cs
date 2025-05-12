using UnityEngine;

public class Apple : Pickup
{
    [Header("Apple Settings")]
    [SerializeField] float increaseChunkSpeed = 3f;

    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkSpeed(increaseChunkSpeed);
    }
}
