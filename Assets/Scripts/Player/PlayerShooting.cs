using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //Publicas
    

    //Privadas
    [SerializeField] int currentWeapon;
    public GameObject[] weapon;
    WeaponProp weaponProp;
    

    public int GetCurrentWeapon()
    {
        return currentWeapon;
    }
    public void SetCurrentWeapon(int currentWeapon)
    {
        this.currentWeapon = currentWeapon;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.timeScale == 1)
        {
            switch (currentWeapon)
            {
                case 0:
                    weapon[currentWeapon].GetComponent<ProjectileWeapon>().ProjectileCreation();
                    break;
                case 1:
                    weapon[currentWeapon].GetComponent<BowWeapon>().ArrowCreation();
                    break;
                case 2:
                    weapon[currentWeapon].GetComponent<SMG>().ShootCreation();
                    break;
                case 3:
                    weapon[currentWeapon].GetComponent<BeamWeaponScript>().BeamCreation();
                    break;
                case 4:
                    weapon[currentWeapon].GetComponent<KnifeScript>().MouseClicks();
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangeWeapon(int index)
    {
        weapon[currentWeapon].SetActive(false);
        weapon[index].SetActive(true);
        int aux = currentWeapon;
        currentWeapon = index;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WeaponProp>())
        {
            weaponProp = other.GetComponent<WeaponProp>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WeaponProp>())
        {
            weaponProp = null;
        }
    }
}
