using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushPhysics : MonoBehaviour
{
    public float force;
    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * force;
    }
}
