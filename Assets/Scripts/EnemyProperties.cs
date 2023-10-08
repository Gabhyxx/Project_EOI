using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public GameObject player;
    public GameObject healthText;
    public int damage;

    private bool isDamaged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitboxPlayer"))
        {
            healthText = GameObject.Find("HealthText");
            healthText.GetComponent<HealthInfo>().TakeDamage(damage);
            isDamaged = true;
        }
    }
}
