using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlanetDweller : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float directionChangeTime = 3f;

    private Rigidbody rb;

    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        PickNewDirection();
    }

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;

        if (timer <= 0f)
        {
            PickNewDirection();
        }

        Vector3 movement = moveDirection * moveSpeed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        // Optional: face movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                5f * Time.fixedDeltaTime
            );
        }
    }

    void PickNewDirection()
    {
        Vector2 random = Random.insideUnitCircle.normalized;

        Vector3 localRight = transform.right;
        Vector3 localForward = Vector3.Cross(transform.up, localRight);

        moveDirection = (Random.value < 0.3f) ? Vector3.zero : (localRight * random.x + localForward * random.y).normalized;

        timer = directionChangeTime;
    }
}