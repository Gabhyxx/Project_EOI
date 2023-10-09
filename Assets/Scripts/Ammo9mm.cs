using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo9mm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player" && other.GetComponent<Player>().ammo9mm < 4)
        {
            other.GetComponent<Player>().ammo9mm = 4;
            Destroy(this.gameObject);
        }
    }
}
