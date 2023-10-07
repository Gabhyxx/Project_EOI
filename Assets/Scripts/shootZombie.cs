using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootZombie : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyAfterDelay(3f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); 

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hacer daño");
        }
    }
}
