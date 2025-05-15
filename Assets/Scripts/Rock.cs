using UnityEngine;
using Unity.Cinemachine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticle;
    [SerializeField] float impulseModifier = 10f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float cooldown = 1f;

    CinemachineImpulseSource cinemachineImpulseSource;
    float cooldownTimer = 1f;

    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < cooldown) return;

        FireImpulse();
        CollisionFX(other);

        cooldownTimer = 0f;
    }

    void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float intensity = (1f / distance) * impulseModifier;
        intensity = Mathf.Min(intensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(intensity);
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contact = other.contacts[0];
        collisionParticle.transform.position = contact.point;
        collisionParticle.Play();
        audioSource.Play();
    }
}
