using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cheese : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   protected void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        rend.material.color = new Color(
            Random.value,
            Random.value,
           0
        );
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
