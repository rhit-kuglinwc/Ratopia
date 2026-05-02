using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour
{

    private FauxGravityAttractor attractor;
    private Transform myTransform;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
        attractor = FauxGravityAttractor.FindClosestAttractor(myTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(myTransform, GetComponent<Rigidbody>());
    }
    
}
