using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityAttractor : MonoBehaviour
{

    private float mass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public readonly static HashSet<FauxGravityAttractor> Pool = new();

    private void OnEnable()
    {
        Pool.Add(this);
    }

    private void OnDisable()
    {
        Pool.Remove(this);
    }
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Rigidbody>().useGravity = false;
        mass = GetComponent<Rigidbody>().mass;
    }

    public Vector3 Attract(Transform body, Rigidbody rigid)
    {
        Vector3 direction = body.position - transform.position;
        float dis = direction.magnitude;
        Vector3 gravityDown = -direction.normalized;
        Vector3 bodyUp = body.up;
        float g = 0.01f;
        if (dis <= 0.0001f) return Vector3.zero;

        float forceM = g * (mass * rigid.mass) / (dis * dis);
        Vector3 force = gravityDown * forceM;
        if(Mathf.Approximately(force.x, 0.001f))    force.x = 0f;
        if(Mathf.Approximately(force.y, 0.001f))    force.y = 0f;
        if(Mathf.Approximately(force.z, 0.001f))    force.z = 0f;
        rigid.AddForce(force);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, -gravityDown) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
        return force;
    }

    public static FauxGravityAttractor FindClosestAttractor(Vector3 pos)
    {
        FauxGravityAttractor result = null;
        float dist = float.PositiveInfinity;
        var a = Pool.GetEnumerator();
        while(a.MoveNext())
        {
            float d = (a.Current.transform.position - pos).sqrMagnitude;
            if(d < dist)
            {
                result = a.Current;
                dist = d;
            }
        }
        return result;
    }
}
