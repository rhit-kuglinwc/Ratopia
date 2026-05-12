using UnityEngine;
using UnityEngine.InputSystem;

public class Eat : MonoBehaviour
{
    public float eatDistance = 3f;
    public LayerMask edibleLayer;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
            TryEat();
    }

    void TryEat()
    {
        // Ray ray = new(transform.position, transform.forward);

        // if (Physics.Raycast(ray, out RaycastHit hit, eatDistance, edibleLayer))
        // {
        //     GameObject target = hit.collider.gameObject;

        //     Debug.Log("Ate: " + target.name);

        //     Destroy(target);
        // }
        // else
        // {
        //     Debug.Log("No Ate");
        // }
        Vector3 center = transform.position + transform.forward * 2f;
        float radius = 1.5f;

        Collider[] hits = Physics.OverlapSphere(center, radius, edibleLayer);

        foreach (Collider hit in hits)
        {
            Destroy(hit.gameObject);
        }
    }
}