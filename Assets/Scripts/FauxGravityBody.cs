using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(Renderer))]
public class FauxGravityBody : MonoBehaviour
{

    private FauxGravityAttractor attractor;
    private Transform myTransform;

    public float minGravity = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        Physics.gravity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
        attractor = FauxGravityAttractor.FindClosestAttractor(myTransform.position);

        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color(
            Random.value,
            Random.value,
           0
        );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 force = attractor.Attract(myTransform, GetComponent<Rigidbody>());
        Debug.Log(force);
        Debug.DrawRay(myTransform.position, force * 1000, Color.red);
        if(Mathf.Abs(force.x) <= minGravity
            && Mathf.Abs(force.y) <= minGravity
            && Mathf.Abs(force.z) <= minGravity)
            attractor = FauxGravityAttractor.FindClosestAttractor(myTransform.position);
    }
    
}
