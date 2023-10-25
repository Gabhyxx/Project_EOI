using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] bool blocked;
    [SerializeField] float distanceToOpen;

    [SerializeField] Transform player;

    public GameObject tutorialDoor;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        blocked = true;
    }


    void Update()
    {
        if (blocked) Door();
    }

    public void Door()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < distanceToOpen)
        {
            tutorialDoor.SetActive(true);
        }
        else
        {
            tutorialDoor.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && distance < distanceToOpen)
        {
            blocked = false;
            anim.Play("Open");
            tutorialDoor.SetActive(false);
        }
    }
}
