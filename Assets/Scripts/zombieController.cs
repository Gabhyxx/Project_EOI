using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class zombieController : MonoBehaviour
{
    public Transform player;

    bool isHunting;

    public float alertRange, attackRange;
    public bool canShoot;
    public LayerMask playerMask;
    NavMeshAgent agent;
    Animator anim;

    public int health = 100;

    [Header("Shoot")]
    public GameObject projectile;
    public Transform shootPoint;
    public float shootForce;
    public float cadency;
    float timeLastShoot;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            getHurt(120);
        }
        else if (health > 0)
        { //Chequea Estado
            checkState();
        }
    }

    private void checkState()
    {
        //detecta Cercania
        isHunting = Physics.CheckSphere(transform.position, alertRange, playerMask);
        float distance = Vector3.Distance(transform.position, player.position);

        // El enemigo te sigue
        if (isHunting && VisionLine())
        {
            anim.SetBool("Hunting", true);
            anim.SetFloat("velocity",agent.velocity.magnitude);

            agent.destination = player.position;

            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                Attacking();
            }
            else anim.SetBool("Attacking", false);
        }

        // El enemigo deja de seguirte
        if (agent.destination == transform.position)
        {
            anim.SetBool("Hunting", false);
        }
    }

    private void Attacking()
    {
        agent.velocity = Vector3.zero;
        if (!canShoot)
            anim.SetBool("Attacking", true);
            
        else if (Time.time > timeLastShoot + cadency)
            anim.Play("roar");
    }

    public void Shoot()
    {
        transform.LookAt(player);
        GameObject newProjectile = Instantiate(projectile, new Vector3(shootPoint.position.x - 0.5f, shootPoint.position.y, shootPoint.position.z), shootPoint.rotation);
        if (Vector3.Distance(transform.position, player.position) > 6f)
        {
            newProjectile.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
        }
        else if (Vector3.Distance(transform.position, player.position) > 4f)
        {
            newProjectile.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce / 1.5f);
        }
        {
            newProjectile.GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce/2);
        }
        timeLastShoot = Time.time;
    }

    public void getHurt(int damage)
    {
        if (health > 0)
        {
            //Enemigo sufre daño

            health -= damage;
            StartCoroutine(ResetHurtState());
        }
    }

    private IEnumerator ResetHurtState()
    {
        anim.SetBool("Hurt", true);
        agent.enabled = false;
        yield return new WaitForSeconds(0.65f);
        agent.enabled = true;
        anim.SetBool("Hurt", false);

        //Enemigo muere
        if (health <= 0)
        {
            bool randomDead = UnityEngine.Random.Range(0, 2) == 0;
            if (randomDead)
            {
                anim.SetBool("Dead", true);
                anim.SetBool("randomDead", true);
            }
            else
            {
                anim.SetBool("Dead", true);
                anim.SetBool("randomDead", false);
            }
            yield return new WaitForSeconds(4);
            agent.enabled = false;

            for (int i = 0; i < 40; i++)
            {
                transform.position -= Vector3.up * 0.05f;
                yield return new WaitForSeconds(0.05f);
            }
            Destroy(gameObject);
        }
    }

    bool VisionLine()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        RaycastHit hitInfo;

        // Lanza un rayo desde la posición del enemigo en la dirección del objetivo
        if (Physics.Raycast(transform.position, direction, out hitInfo, distance, ~LayerMask.GetMask("Trigger"), QueryTriggerInteraction.Ignore))
        {
            // Si el rayo golpea al player devuelve true
            if (hitInfo.collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);

        
        if (canShoot)
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        
        if (!canShoot)
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet")){
            //int damage = 50;
            //if getHurt(damage);
        }
    }



}
