using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoInfo : MonoBehaviour
{
    private TMP_Text textComponent;
    public int ammoCharged;
    public int ammoUncharged;
    public GameObject player;
    public GameObject weapon;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        if (player.GetComponent<PlayerShooting>().GetCurrentWeapon() == 0)
        {
            
            ammoUncharged = weapon.GetComponent<ProjectileWeapon>().maxAmmo;
            ammoCharged = weapon.GetComponent<ProjectileWeapon>().chargedAmmo;
        } else if (player.GetComponent<PlayerShooting>().GetCurrentWeapon() == 1)
        {
            ammoUncharged = weapon.GetComponent<BowWeapon>().maxAmmo;
            ammoCharged = weapon.GetComponent<BowWeapon>().chargedAmmo;
        }
        else if (player.GetComponent<PlayerShooting>().GetCurrentWeapon() == 2)
        {
            ammoUncharged = weapon.GetComponent<SMG>().maxAmmoSMG;
            ammoCharged = weapon.GetComponent<SMG>().ammoSMG;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerShooting>().GetCurrentWeapon() == 0)
        {
            ammoCharged = weapon.GetComponent<ProjectileWeapon>().chargedAmmo;
            ammoUncharged = weapon.GetComponent<ProjectileWeapon>().maxAmmo;
        }
        else if (player.GetComponent<PlayerShooting>().GetCurrentWeapon() == 1)
        {
            ammoCharged = weapon.GetComponent<BowWeapon>().chargedAmmo;
            ammoUncharged = weapon.GetComponent<BowWeapon>().maxAmmo;
        }
        else if (player.GetComponent<PlayerShooting>().GetCurrentWeapon() == 2)
        {
            ammoUncharged = weapon.GetComponent<SMG>().maxAmmoSMG;
            ammoCharged = weapon.GetComponent<SMG>().ammoSMG;
        }
        textComponent.text = ammoCharged + "/" + ammoUncharged;
    }


    //Para optimizar. By Gabhyxx c:
    void ammunitionInfo()
    {

    }
}
