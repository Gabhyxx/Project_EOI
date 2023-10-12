using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushHitbox : MonoBehaviour
{
    public GameObject pushCapsule;
    public Transform pushPosition;
    private void Start()
    {
        pushPosition.Rotate(new Vector3(0, 0, 90));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        { 
            Instantiate(pushCapsule, pushPosition.position - transform.forward*1.5f, pushPosition.rotation);
        }
    }
    
}
