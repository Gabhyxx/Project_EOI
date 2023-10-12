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
    public GameObject pistol;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        if (player.GetComponent<PlayerShooting>().GetCurrentWeapon() == 0)
        {
            
            ammoUncharged = pistol.GetComponent<ProjectileWeapon>().maxAmmo;
            ammoCharged = pistol.GetComponent<ProjectileWeapon>().chargedAmmo;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ammoCharged = pistol.GetComponent<ProjectileWeapon>().chargedAmmo;
        textComponent.text = ammoCharged + "/" + ammoUncharged;
    }
}
