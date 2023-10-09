using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeapon : MonoBehaviour
{
    public float arrowForce;

    public GameObject arrowPrefab;
    public Transform arrowInstantiatePoint;

    public float cadency;
    float timeLastShoot;

    private void Start()
    {
        cadency = 60/cadency;
    }

    public void ArrowCreation()
    {
        if(Time.time > timeLastShoot + cadency)
        {
            GameObject cloneArrow = Instantiate(arrowPrefab, arrowInstantiatePoint.position, Camera.main.transform.rotation);
            cloneArrow.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * arrowForce);

            Destroy(cloneArrow, 20);
            timeLastShoot = Time.time;
        }
    }

}
