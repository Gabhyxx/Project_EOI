using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    
    public float cadency;
    float timeLastShoot;

    Animator anim;

    //Variables Raycast
    public Transform shootingTransform;
    public float range;
    public LayerMask layerShootable;
    public LineRenderer line;
    public Light lights;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        cadency = 60 / cadency;
    }

    private void Update()
    {
        ADS();
    }

    public void ShootCreation()
    {
        if(Time.time> timeLastShoot+cadency) 
        {
            StartCoroutine(Shoot());
            timeLastShoot = Time.time;
        }
    }

    IEnumerator Shoot()
    {
        lights.enabled = true;
        line.enabled = true;
        line.SetPosition(0, shootingTransform.position);
        if (Physics.Raycast(shootingTransform.position, shootingTransform.forward, out RaycastHit hitInfo, range, layerShootable))
        {
            line.SetPosition(1, hitInfo.point);
        }
        else
        {
            line.SetPosition(1, shootingTransform.position + shootingTransform.forward * range);
        }
        yield return new WaitForEndOfFrame();
        lights.enabled = false;
        line.enabled = false;
    }

    void ADS()
    {
        if (Input.GetMouseButton(1))
        {
            anim.SetBool("isAiming", true);
        }
        else
        {
            anim.SetBool("isAiming", false);
        }
    }
}
