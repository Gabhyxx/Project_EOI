using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] bool blocked;
    [SerializeField] float distanceToOpen;

    [SerializeField] Transform player;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        blocked = true;
    }


    void Update()
    {
        Door();
    }

    public void Door()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (blocked = true && Input.GetKeyDown(KeyCode.E) && distance < distanceToOpen)
        {
            blocked = false;
            anim.Play("Open");
        }
    }
}
