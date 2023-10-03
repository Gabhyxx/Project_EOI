using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthInfo : MonoBehaviour
{
    public GameObject player;
    private TMP_Text textComponent;
    public int maxHealth = 100;
    public int health;

    private void Start()
    {
        health = player.GetComponent<Player>().health;
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<Player>().health;
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = health+"%";
    }

    public void TakeDamage(int damage)
    {
        player.GetComponent<Player>().health -= damage;
        if (health < 0)
        {
            player.GetComponent<Player>().health = 0;
        }
    }

}
