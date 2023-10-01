using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int velocity = 12;
    public int mouseSensitivity = 120;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Movimiento con teclas
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * horizontalMove + transform.forward * verticalMove;

        if (movement != Vector3.zero)
        {
            transform.Translate(movement * velocity * Time.deltaTime, Space.World);
        }

        // Rotación con ratón
        float movementMouseHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * movementMouseHorizontal, Space.World);
    }
}
