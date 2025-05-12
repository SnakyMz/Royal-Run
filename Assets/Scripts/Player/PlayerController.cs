using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float speed = 5f;
    [SerializeField] float range = 4f;

    Vector2 movement;

    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void HandleMovement()
    {

        Vector3 currentPosition = rigidBody.position;
        Vector3 input = new Vector3(movement.x, 0, movement.y);
        Vector3 moveDirection = currentPosition + input * (speed * Time.fixedDeltaTime);

        moveDirection.x = Mathf.Clamp(moveDirection.x, -range, range);
        moveDirection.z = Mathf.Clamp(moveDirection.z, -range, range);
        
        rigidBody.MovePosition(moveDirection);
    }
}
