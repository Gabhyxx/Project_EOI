using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public int playerPosStartX;
    public int playerPosFinishX;
    public int playerPosStartY;
    public int playerPosFinishY;
    public GameObject[] zombies; // Arreglo de prefabs
    public int zombiesNumber;
    public int timeToSpawn;


    private float playerX;
    private float playerY;

    public bool needZombieEncounter;
    void Start()
    {
        InvokeRepeating("Spawn", 0f, timeToSpawn);

    }

    void Spawn()
    {
        playerX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        playerY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        if ( (!needZombieEncounter || bossController.instance.bossEncounter) && (playerX > playerPosStartX) && (playerX < playerPosFinishX) && (playerY > playerPosStartY) && (playerY < playerPosFinishY) && bossController.instance.health>0)
        {
            for (int i = 0; i < zombiesNumber; i++)
            {
                int randomIndex = Random.Range(0, zombies.Length); // Genera un índice aleatorio
                GameObject prefabToSpawn = zombies[randomIndex]; // Selecciona un prefab aleatorio
                Instantiate(prefabToSpawn, transform.position, Quaternion.identity); // Instancia el prefab
            }
        }
    }
}
