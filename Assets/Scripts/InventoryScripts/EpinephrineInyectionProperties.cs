using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpinephrineInyectionProperties : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player" && other.GetComponent<Player>().epinephrineInjection == 0)
        {
            other.GetComponent<Player>().epinephrineInjection = 1;
            Destroy(this.gameObject);
        }
    }
}
