using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject healthText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("PRUEBA");
            if (GetComponent<Player>().epinephrineInjection == 1)
            {
                healthText.GetComponent<HealthInfo>().GainHealth(75);
                GetComponent<Player>().epinephrineInjection = 0;
                GetComponent<Movement>().velocity = GetComponent<Movement>().velocity * 1.05f;
                Invoke("SlowDown", 30f);
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            healthText.GetComponent<HealthInfo>().TakeDamage(other.GetComponent<EnemyProperties>().damage);
        }
    }
    void SlowDown()
    {
        GetComponent<Movement>().velocity = GetComponent<Movement>().velocity * 1.05f;
    }
}
