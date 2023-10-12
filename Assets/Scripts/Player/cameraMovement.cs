using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cameraMovement : MonoBehaviour
{

    public int  mouseSensitivity = 120;
    public int maxVerticalAngle = 15;
    public int minVerticalAngle = 0;

    float verticalRotation = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float movementMouseVertical = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= movementMouseVertical;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0);

    }
}