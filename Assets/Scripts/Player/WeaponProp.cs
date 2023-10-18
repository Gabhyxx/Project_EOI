using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProp : MonoBehaviour
{
    public int weaponIndex;
    public GameObject[] weaponModel;

    private void Start()
    {
        weaponModel[weaponIndex].SetActive(true);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 0.05f);
    }

    public void ChangeWeapon(int index)
    {
        Debug.Log(index);
        weaponModel[weaponIndex].SetActive(false);
        weaponIndex = index;
        weaponModel[weaponIndex].SetActive(true);
    }
}
