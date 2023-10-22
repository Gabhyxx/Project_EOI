using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] OpenDoor openDoor;

    private void Update()
    {
        OpeningDoor();
    }

    void OpeningDoor()
    {
        if (openDoor.blocked == false)
        {
            openDoor.anim.Play("Open");
        }
    }


}
