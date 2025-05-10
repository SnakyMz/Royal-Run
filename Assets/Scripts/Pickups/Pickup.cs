using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    const string playerTag = "Player";

    void Update()
    {
        RotatePickup();
    }

    void RotatePickup()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            OnPickup();
        }
    }

    protected abstract void OnPickup();
}
