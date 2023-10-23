using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int batteries;
    public int epinephrineInjection;
    public int ammo9mm;
    public int arrowQuiver;

    public void SavePlayer()
    {
        float[] position = { GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z };
        PlayerData playerData = new PlayerData(health, batteries, epinephrineInjection, ammo9mm,
            arrowQuiver, position);
        SaveSystem.SavePlayer(playerData);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        batteries = data.batteries;
        epinephrineInjection = data.epinephrineInjection;
        ammo9mm = data.ammo9mm;
        arrowQuiver = data.arrowQuiver;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
