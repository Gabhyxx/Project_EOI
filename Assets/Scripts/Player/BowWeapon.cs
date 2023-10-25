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
    public int chargedAmmo = 2;
    public int maxAmmo = 25;
    public Animator bowAnim;
    public GameObject player;

    GameObject cloneArrow;
    private void Awake()
    {
        maxAmmo = player.GetComponent<Player>().arrowQuiver * 25;
        chargedAmmo = 2;
        bowAnim = GetComponent<Animator>();
    }
    private void Start()
    {
        cadency = 60/cadency;
    }
    private void Update()
    {
        if(maxAmmo<25 && player.GetComponent<Player>().arrowQuiver > 0)
        {
            maxAmmo = 25;
            player.GetComponent<Player>().arrowQuiver--;
        }
        Animating();
    }
    public void ArrowCreation()
    {
        if(Time.time > timeLastShoot + cadency && chargedAmmo > 0)
        {
            chargedAmmo--;
            cloneArrow = Instantiate(arrowPrefab, arrowInstantiatePoint.position, Camera.main.transform.rotation);
            cloneArrow.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * arrowForce + Camera.main.transform.up * arrowForce/2);

            Destroy(cloneArrow, 20);
            timeLastShoot = Time.time;
        }
    }
    public void RechargingBow()
    {
        Invoke("Reloading", 6.0f);
    }
    public void Reloading()
    {
        if(chargedAmmo < maxAmmo)
        {
            chargedAmmo = 2;
            maxAmmo -= 2;
        }
    }
    void Animating()
    {
        if (Input.GetMouseButton(0))
        {
            bowAnim.SetBool("IsShooting", true);
        }
        else
        {
            bowAnim.SetBool("IsShooting", false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bowAnim.SetBool("IsReloading", true);
        }
        else
        {
            bowAnim.SetBool("IsReloading", false);
        }
    }

}
