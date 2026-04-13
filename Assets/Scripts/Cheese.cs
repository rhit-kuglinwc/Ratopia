using UnityEngine;

public class Cheese : GravityObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   protected override void Start()
    {

        base.Start();
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
