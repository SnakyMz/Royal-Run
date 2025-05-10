using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;

    const string hitTrigger = "Hit";
    float cooldownTimer = 0f;

    void Update()
    {
        cooldownTimer += 1f * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        animator.SetTrigger(hitTrigger);
        cooldownTimer = 0f;
    }
}
