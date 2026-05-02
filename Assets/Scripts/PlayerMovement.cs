using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 10f;
    public Transform cameraTransform;

    private float xRotation = 0f;
    public float mouseSensitivity = 0.1f;
    protected CharacterController controller;

    protected void Update()
    {

        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        Vector3 input = Vector3.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) input.y += 1;
            if (Keyboard.current.sKey.isPressed) input.y -= 1;
            if (Keyboard.current.aKey.isPressed) input.x -= 1;
            if (Keyboard.current.dKey.isPressed) input.x += 1;
            if (Keyboard.current.spaceKey.isPressed && controller.isGrounded) input.z += jumpPower;
        }

        Vector3 move = (transform.right * input.x + transform.forward * input.y) * moveSpeed + transform.up * input.z;
        controller.Move(move * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        if (Mouse.current == null) return;

        Vector2 mouse = Mouse.current.delta.ReadValue();

        float mouseX = mouse.x * mouseSensitivity;
        float mouseY = mouse.y * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}