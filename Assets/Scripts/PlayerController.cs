using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15;
    private Vector3 moveDir;
    public Transform cameraTransform;
    private float xRotation = 0f;
    public float mouseSensitivity = 0.1f;
    public float smellRad = 30f;
    public LayerMask smellLayer;

    // Update is called once per frame
    void FixedUpdate(){
        HandleMouseLook();
        HandleMovement();
        if(Keyboard.current.qKey.isPressed)
            HandleSmell();
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
            (Keyboard.current.spaceKey.isPressed) ? 1 : 0,
            Keyboard.current.wKey.isPressed ? 1 : Keyboard.current.sKey.isPressed ? -1 : 0).normalized;
        rigid.MovePosition(rigid.position + moveSpeed * Time.deltaTime * transform.TransformDirection(moveDir));
    }

    private void HandleSmell()
    {
        Collider[] smells = new Collider[10];
        int amount = Physics.OverlapSphereNonAlloc(transform.position, smellRad, smells, smellLayer);
         foreach (Collider smell in smells){
         }
    }

    /*
    public static int InRadius(Vector3 pos, float radius, out List<T> results, bool findOnlyEnabled = true)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, radius);

        results = new List<T>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out T component))
            {
                if (findOnlyEnabled)
                {
                    Behaviour behaviour = component as Behaviour;

                    if (behaviour)
                    {
                        if (behaviour.enabled)
                            results.Add(component);
                    }
                    else
                    {
                        findOnlyEnabled = false;
                        results.Add(component);
                    }
                }
                else
                {
                    results.Add(component);
                }
            }
        }

        return results.Count;
    }
    */
}
