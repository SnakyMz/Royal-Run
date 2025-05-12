using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator;
    [Header("Collision Settings")]
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float decreaseChunkSpeed = -2f;

    const string hitTrigger = "Hit";
    float cooldownTimer = 0f;

    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTimer += 1f * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkSpeed(decreaseChunkSpeed);

        animator.SetTrigger(hitTrigger);
        cooldownTimer = 0f;
    }
}
