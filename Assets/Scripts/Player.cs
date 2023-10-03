using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int pulseGunAmmo;
    public int submachineGunAmmo;
    public int lightningRifleAmmo;
    public int bowAmmo;
    public int epinephrineInjection;
    public int ammo9mm;
    public int batteryAmmo;
    public int arrowQuiver;
    
    public void SavePlayer()
    {
        float[] position = { GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z };
        PlayerData playerData = new PlayerData(health, pulseGunAmmo, submachineGunAmmo,
            lightningRifleAmmo, bowAmmo, epinephrineInjection, ammo9mm, batteryAmmo,
            arrowQuiver, position);
        SaveSystem.SavePlayer(playerData);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        pulseGunAmmo = data.pulseGunAmmo;
        submachineGunAmmo = data.submachineGunAmmo;
        lightningRifleAmmo = data.lightningRifleAmmo;
        bowAmmo = data.bowAmmo;
        epinephrineInjection = data.epinephrineInjection;
        ammo9mm = data.ammo9mm;
        batteryAmmo = data.batteryAmmo;
        arrowQuiver = data.arrowQuiver;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
