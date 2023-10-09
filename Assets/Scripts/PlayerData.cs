using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int batteries;
    public int epinephrineInjection;
    public int ammo9mm;
    public int arrowQuiver;
    public float[] position;

    public PlayerData(int health, int batteries,
        int epinephrineInjection, int ammo9mm,
        int arrowQuiver, float[] position)
    {
        this.health = health;
        this.batteries = batteries;
        this.epinephrineInjection = epinephrineInjection;
        this.ammo9mm = ammo9mm;
        this.arrowQuiver = arrowQuiver;
        this.position = new float[3];
        this.position[0] = position[0];
        this.position[1] = position[1];
        this.position[2] = position[2];
    }
}
