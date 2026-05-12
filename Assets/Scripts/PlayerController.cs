using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower = 5f;
    private Vector3 moveDir;
    public Transform cameraTransform;
    private float xRotation = 0f;
    public float mouseSensitivity = 0.1f;
    private bool sprintToggled = false;

    // Update is called once per frame
    void FixedUpdate(){
        HandleMouseLook();
        HandleMovement();
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

    private void HandleMovement()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        moveDir = new Vector3(
            Keyboard.current.dKey.isPressed ? 1 : Keyboard.current.aKey.isPressed ? -1 : 0,
            Keyboard.current.spaceKey.isPressed ? jumpPower : 0,
            Keyboard.current.wKey.isPressed ? 1 : Keyboard.current.sKey.isPressed ? -1 : 0).normalized;

        sprintToggled = Keyboard.current.leftShiftKey.isPressed ? !sprintToggled : sprintToggled;
        // moveSpeed = sprintToggled ? 50 : 15;
        moveSpeed = Keyboard.current.leftShiftKey.isPressed ? 50 : 15;
        rigid.MovePosition(rigid.position + moveSpeed * Time.deltaTime * transform.TransformDirection(moveDir));
    }
}
