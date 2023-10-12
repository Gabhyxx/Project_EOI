using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBullet : MonoBehaviour
{
    Rigidbody arrowB;
    Transform transformArrowB; //No se si necesito la variable -Gabhy
    Collider arrowCollider;

    private void Awake()
    {
        arrowB = GetComponent<Rigidbody>();
        transformArrowB = GetComponent<Transform>();
        arrowCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        arrowB.velocity = Vector3.zero;
        arrowB.isKinematic = true;
        if (arrowB.isKinematic == true)
        {
            arrowCollider.enabled = false;
            Destroy(gameObject, 5f);
        }
        else
        {
            Destroy(gameObject, 15f);
        }
        //Vector3 arrowVector = new Vector3 (transformArrowB.position.x, transformArrowB.position.y, transformArrowB.position.z + 1f);
        //transformArrowB.position = arrowVector; ¿Porqué esta la linea comentada? No me acuerdo -Gabhy
        

    }
}
