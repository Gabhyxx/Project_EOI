using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject healthText;
    public GameObject ammoText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GetComponent<Player>().epinephrineInjection == 1)
            {
                healthText.GetComponent<HealthInfo>().GainHealth(75);
                GetComponent<Player>().epinephrineInjection = 0;
                GetComponent<Movement>().velocity = GetComponent<Movement>().velocity * 1.05f;
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
            GetComponent<PlayerShooting>().ChangeWeapon(0);
            ammoText.GetComponent<AmmoInfo>().weapon = GetComponent<PlayerShooting>().weapon[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<PlayerShooting>().ChangeWeapon(1);
            ammoText.GetComponent<AmmoInfo>().weapon = GetComponent<PlayerShooting>().weapon[1];
        }
    }
    
    void SlowDown()
    {
        GetComponent<Movement>().velocity = GetComponent<Movement>().velocity * 1.05f;
    }
}
