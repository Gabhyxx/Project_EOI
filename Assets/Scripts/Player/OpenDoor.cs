using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool blocked;
    public float distanceToOpen;

    public Transform player;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>(); 
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (!blocked && distance < distanceToOpen)
        {
            blocked = true;
            anim.Play("Open");
        }
    }
}
