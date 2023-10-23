using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
    AudioSource audioSource;
    [SerializeField] AudioClip reloadClip;
    [SerializeField] AudioClip shootingClip;


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
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        cadency = 60 / cadency;
    }

    private void Update()
    {
        ADS();
        Animating();
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
            else if (hitInfo.collider.tag == "Enemy")
            {
                Debug.Log(hitInfo.collider.name);
                hitInfo.collider.gameObject.GetComponent<zombieController>().GetHurt(damage);
            }
            
        }
        else
        {
            line.SetPosition(1, shootingTransform.position + shootingTransform.forward * range);
        }
        yield return new WaitForEndOfFrame();
        ammoSMG--;
        audioSource.clip = shootingClip;
        audioSource.Play();
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammoSMG == maxAmmoPerMagazine)
            {
                ammoSMG = maxAmmoPerMagazine;
            }
            else if (maxAmmoSMG <= 0)
            {
                maxAmmoSMG = 0;
            }
            else
            {
                maxAmmoSMG = maxAmmoSMG - maxAmmoPerMagazine;
                ammoSMG = maxAmmoPerMagazine;
            }
        }
    }

    void Animating()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("isReloading", true);
            audioSource.clip = reloadClip;
            audioSource.Play();
        }
        else
        {
            anim.SetBool("isReloading", false);
        }
    }
}
