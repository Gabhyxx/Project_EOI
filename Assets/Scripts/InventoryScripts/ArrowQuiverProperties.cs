using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowQuiverProperties : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<Player>().arrowQuiver == 0)
        {
            other.GetComponent<Player>().arrowQuiver = 1;
            Destroy(this.gameObject);
        }
    }
}
