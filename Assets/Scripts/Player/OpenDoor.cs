using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool blocked;
    //public float distanceToOpen;

    public Transform player;

    public Animator anim;

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
        //float distance = Vector3.Distance(transform.position, player.position);

        if (blocked = true && Input.GetKeyDown(KeyCode.F))
        {
            blocked = false;
            anim.Play("Open");
        }
    }
}
