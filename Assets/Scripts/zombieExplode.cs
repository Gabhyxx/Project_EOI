using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class zombieExplode : MonoBehaviour
{
    public Transform player;
    public float explosionRange;
    public ParticleSystem explosionParticles;

    public float shakeAmount;
    public float shakeTime;
    public float shakeSpeed;

    public AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0f,0f,1f,1f);
    public float scaleAmount = 1.1f;
    public float scaleTime = 0.5f;

    public GameObject healthText;
    public int damage;


    private void Update()
    {
        if (canExplode() &&  GetComponent<zombieController>().health  > 0){
            Explode();
        }
    }

    private void Explode()
    {
        StartCoroutine(ExplosionCoroutine());

    }

    private IEnumerator ExplosionCoroutine()
    {
        Coroutine shakeCoroutine = StartCoroutine(SimpleShakeCoroutine());
        float currentScaleTime = 0f;
        Vector3 originalScale = transform.localScale;
        while (currentScaleTime < scaleTime){
            float dt = currentScaleTime / scaleTime;
            Vector3 newScale = originalScale + originalScale * scaleCurve.Evaluate(dt) * (scaleAmount -1f);
            transform.localScale = newScale;
            currentScaleTime += Time.deltaTime;
            yield return null;
        }

        yield return shakeCoroutine;


        ParticleSystem explossionEffect = Instantiate(explosionParticles, transform.position, Quaternion.identity);

        //hacer daño al jugador

        Destroy(gameObject);

        

        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, direction, out hitInfo, distance, ~LayerMask.GetMask("Trigger"), QueryTriggerInteraction.Ignore))
        {
            // Si el rayo golpea al player devuelve true
            if (hitInfo.collider.CompareTag("Player") && distance < explosionRange)
            {
                healthText.GetComponent<HealthInfo>().TakeDamage(damage);
            }
        }


    }

 
    private IEnumerator SimpleShakeCoroutine()
    {
        Vector3 initialPosition = transform.localPosition;
        float endTime = Time.time + shakeTime;
        while (Time.time < endTime) { 
            Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * shakeAmount;
            transform.localPosition = initialPosition + randomPoint;
            yield return null;
        }
        transform.localPosition = initialPosition;
    }


    bool canExplode()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        RaycastHit hitInfo;

        // Lanza un rayo desde la posición del enemigo en la dirección del objetivo
        if (Physics.Raycast(transform.position, direction, out hitInfo, distance, ~LayerMask.GetMask("Trigger"), QueryTriggerInteraction.Ignore))
        {
            // Si el rayo golpea al player devuelve true
            if (hitInfo.collider.CompareTag("Player") && distance<explosionRange)
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
