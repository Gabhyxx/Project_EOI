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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {
            healthText.GetComponent<HealthInfo>().TakeDamage(other.GetComponent<EnemyProperties>().damage);
        }
    }
}
