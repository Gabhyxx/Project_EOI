using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    //Variables Públicas
    public float destroyTime = 5,
                 projectileForce;

    public GameObject pistolProjectile;
    public Transform shootingTransform;
    public float cadency;
    //Variables Privadas
    GameObject cloneProjectile;
    float timeLastShoot;

    private void Start()
    {
        cadency = 60 / cadency;
    }
    public void ProjectileCreation()
    {
        if(Time.time > timeLastShoot + cadency)
        {
            cloneProjectile = Instantiate(pistolProjectile, shootingTransform.position, shootingTransform.rotation);
            cloneProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce);
            Destroy(cloneProjectile, destroyTime);
            timeLastShoot = Time.time;
        }
        
    }
}
