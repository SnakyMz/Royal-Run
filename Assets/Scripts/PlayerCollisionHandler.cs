using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    const string hitTrigger = "Hit";

    void OnCollisionEnter(Collision other)
    {
        animator.SetTrigger(hitTrigger);
    }
}
