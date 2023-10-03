using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
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
    public float[] position;

    /*public PlayerData (PlayerData player)
    {
        health = player.health;
        pulseGunAmmo = player.pulseGunAmmo;
        submachineGunAmmo = player.submachineGunAmmo;
        lightningRifleAmmo = player.lightningRifleAmmo;
        bowAmmo = player.bowAmmo;
        epinephrineInjection = player.epinephrineInjection;
        ammo9mm = player.ammo9mm;
        batteryAmmo = player.batteryAmmo;
        arrowQuiver = player.arrowQuiver;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }*/
    public PlayerData(int health, int pulseGunAmmo, int submachineGunAmmo,
        int lightningRifleAmmo, int bowAmmo, int epinephrineInjection,
        int ammo9mm, int batteryAmmo, int arrowQuiver, float[] position)
    {
        this.health = health;
        this.pulseGunAmmo = pulseGunAmmo;
        this.submachineGunAmmo = submachineGunAmmo;
        this.lightningRifleAmmo = lightningRifleAmmo;
        this.bowAmmo = bowAmmo;
        this.epinephrineInjection = epinephrineInjection;
        this.ammo9mm = ammo9mm;
        this.batteryAmmo = batteryAmmo;
        this.arrowQuiver = arrowQuiver;
        this.position = new float[3];
        this.position[0] = position[0];
        this.position[1] = position[1];
        this.position[2] = position[2];
    }
}
