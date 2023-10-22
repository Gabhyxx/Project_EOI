using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    //Munición
    [SerializeField] int maxAmmoPerMagazine;
    public int ammoSMG;
    public int maxAmmoSMG;
    
    public float cadency;
    float timeLastShoot;

    Animator anim;
    

    //Variables Raycast
    public Transform shootingTransform;
    public float range;
    public LayerMask layerShootable;
    public LineRenderer line;
    public Light lights;

    public float damage;

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
        SMGReload();
        Debug.DrawRay(shootingTransform.position, shootingTransform.forward * range, Color.red);
    }

    public void ShootCreation()
    {
        if(Time.time> timeLastShoot+cadency) 
        {
            if (ammoSMG > 0)
            {
                StartCoroutine(Shoot());
                timeLastShoot = Time.time;
            }
            
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
            if (hitInfo.collider.gameObject.name == "Boss") 
            {
                hitInfo.collider.gameObject.GetComponent<bossController>().GetHurt(damage);
            }
            else
            {
                hitInfo.collider.gameObject.GetComponent<zombieController>().GetHurt(damage);
            }
        }
        else
        {
            line.SetPosition(1, shootingTransform.position + shootingTransform.forward * range);
        }
        yield return new WaitForEndOfFrame();
        ammoSMG--;
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

    void SMGReload()
    {
        if ((ammoSMG <= 0 && maxAmmoSMG > 0) || (ammoSMG < 30 && maxAmmoSMG > 0 && Input.GetKeyDown(KeyCode.R)))
        {
            Invoke("Reloading", 3f);
        }
        else if (maxAmmoSMG <= 0 && ammoSMG <= 0)
        {
            maxAmmoSMG = 0;
            ammoSMG = 0;
        }
        else if (maxAmmoSMG <= 0)
        {
            maxAmmoSMG = 0;
        }
    }

    void Reloading()
    {
        ammoSMG = 30;
        maxAmmoSMG = maxAmmoSMG - 30; ;
    }

    void Animating()
    {

    }
}
