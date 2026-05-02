using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class GravityObject : MonoBehaviour
{
    protected CharacterController controller;

    [Header("Gravity Settings")]
    public float gravity = -0.981f;
    protected Vector3 velocity;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    protected virtual void Update()
    {
        ApplyGravity();
    }

    protected void ApplyGravity()
    {
        if (!controller.isGrounded && velocity.y <= 0)
            velocity.y = (velocity.y >= gravity) ? gravity : velocity.y + gravity;
        controller.Move(velocity * Time.deltaTime);
    }
}