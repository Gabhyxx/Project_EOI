using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthInfo : MonoBehaviour
{
    private TMP_Text textComponent;
    public int maxHealth = 100;
    public int health;

    private void Start()
    {
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = health+"%";
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

}
