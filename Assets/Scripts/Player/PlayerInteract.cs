using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject healthText;
    public GameObject ammoText;

    PlayerShooting playerShooting;
    Player player;
    Movement movement;
    private void Awake()
    {
        playerShooting = GetComponent<PlayerShooting>();
        player = GetComponent<Player>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (player.epinephrineInjection == 1)
            {
                healthText.GetComponent<HealthInfo>().GainHealth(75);
                player.epinephrineInjection = 0;
                movement.velocity = movement.velocity * 1.05f;
                Invoke("SlowDown", 30f);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(GetComponent<PlayerShooting>().GetCurrentWeapon() == 1)
            {
                ammoText.GetComponent<AmmoInfo>().weapon.GetComponent<BowWeapon>().RechargingBow();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerShooting.ChangeWeapon(0);
            ammoText.GetComponent<AmmoInfo>().weapon = playerShooting.weapon[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerShooting.ChangeWeapon(1);
            ammoText.GetComponent<AmmoInfo>().weapon = playerShooting.weapon[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerShooting.ChangeWeapon(2);
            ammoText.GetComponent<AmmoInfo>().weapon = playerShooting.weapon[2];
        }
    }
    
    void SlowDown()
    {
        movement.velocity = movement.velocity = movement.velocity * 1.05f;
    }
}
