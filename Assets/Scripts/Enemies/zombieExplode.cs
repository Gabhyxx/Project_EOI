using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class zombieExplode : MonoBehaviour
{
    [Header("Exploting")]
    public AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    public float scaleAmount, scaleTime;
    public ParticleSystem explosionParticles;
    public float explosionRange;
    public float explosionDamageRange;
    public float timeCounter;

    private bool isExploting = false;

    [Header("Player")]
    public int damage;
    private Transform player;
    public LayerMask layerPlayer;
    private GameObject healthText;

    [Header("Sounds")]
    public AudioSource alarmSound;
    public AudioSource explosionSound;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthText = GameObject.FindGameObjectWithTag("HealthText");
    }

    private void Update()
    {
        if (canExplode() && GetComponent<zombieController>().health > 0 && isExploting == false)
        {
            Explode();
        }
    }

    bool canExplode()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        RaycastHit hitInfo;

        // Lanza un rayo desde la posición del enemigo en la dirección del objetivo
        if (Physics.Raycast(transform.position, direction, out hitInfo, distance, layerPlayer))
        {
            // Si el rayo golpea al player devuelve true
            if (hitInfo.collider.CompareTag("HitboxPlayer") && distance < explosionRange)
            {
                return true;
            }
        }

        return false;
    }

    private void Explode()
    {
        if (!alarmSound.isPlaying) alarmSound.Play();
        isExploting = true;
        StartCoroutine(ExplosionCoroutine());

    }

    private IEnumerator ExplosionCoroutine()
    {
        float currentScaleTime = 0f;
        Vector3 originalScale = transform.localScale;
        while (currentScaleTime < scaleTime)
        {
            float dt = currentScaleTime / scaleTime;
            Vector3 newScale = originalScale + originalScale * scaleCurve.Evaluate(dt) * (scaleAmount - 1f);
            transform.localScale = newScale;
            currentScaleTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.15f);
        ParticleSystem explossionEffect = Instantiate(explosionParticles, transform.position, Quaternion.identity);

        //hacer daño al jugador

        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < explosionDamageRange) healthText.GetComponent<HealthInfo>().TakeDamage(damage);

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionDamageRange);
    }
}
