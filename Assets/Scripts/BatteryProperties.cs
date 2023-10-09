using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryProperties : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name =="Player" && other.GetComponent<Player>().batteries < 2)
        {
            other.GetComponent<Player>().batteries = 2;
            Destroy(this.gameObject);
        }
    }
}
