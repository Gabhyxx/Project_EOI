using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    public float velocity = 12f;
    public int mouseSensitivity ;
    public int dashForce;
    public int timeToDash;

    private bool canDash = true;
    private Rigidbody rig;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rig = GetComponent<Rigidbody>();
        mouseSensitivity = OptionMenu.instance.sensivility;
    }

    private void Update()
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
            rig.velocity = movement * velocity* Time.deltaTime + Vector3.up * rig.velocity.y;
            //transform.Translate(movement * velocity * Time.deltaTime, Space.World);
            if (Input.GetKeyDown(KeyCode.Space) && canDash)
            {
                Dash();
            }
        }

        // Rotación con ratón
        float movementMouseHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * movementMouseHorizontal, Space.World);
    }

    private void Dash()
    {
        canDash = false;
        rig.velocity = Vector3.zero;
        rig.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        rig.velocity = Vector3.zero; 
        StartCoroutine(ResetDashCooldown());
    }

    private IEnumerator ResetDashCooldown()
    {
        yield return new WaitForSeconds(timeToDash);
        canDash = true;
    }
}
