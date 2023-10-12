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
    public int chargedAmmo = 20;
    public int maxAmmo = 20;
    //Variables Privadas
    GameObject cloneProjectile;
    float timeLastShoot;
    int timePassed = 0;

    private void Start()
    {
        cadency = 60 / cadency;
    }
    private void Update()
    {
        timePassed++;
        RechargingPistol();
        if (Input.GetMouseButton(0))
        {
            CancelInvoke();
        }
    }
    public void ProjectileCreation()
    {
        if(Time.time > timeLastShoot + cadency && chargedAmmo > 0)
        {
            chargedAmmo--;
            cloneProjectile = Instantiate(pistolProjectile, shootingTransform.position, shootingTransform.rotation);
            cloneProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce);
            Destroy(cloneProjectile, destroyTime);
            timeLastShoot = Time.time;
        }
    }
    public void RechargingPistol()
    {
        Invoke("Reloading", 3.0f);
    }
    public void Reloading()
    {
        if(chargedAmmo < maxAmmo && timePassed % 15f == 0)
        {
            chargedAmmo++;
        }
    }
}
