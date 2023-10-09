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

    void Update()
    {
        if (Input.GetMouseButton(0))
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
        //--------------------------------------- PRUEBAS, BORRAR LUEGO
        if (Input.GetKeyDown(KeyCode.P) && weaponProp != null)
        {
            ChangeWeapon(weaponProp.weaponIndex);
        }
    }

    public void ChangeWeapon(int index)
    {
        weapon[currentWeapon].SetActive(false);
        weapon[index].SetActive(true);
        int aux = currentWeapon;
        currentWeapon = weaponProp.weaponIndex;
        weaponProp.ChangeWeapon(aux);
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
