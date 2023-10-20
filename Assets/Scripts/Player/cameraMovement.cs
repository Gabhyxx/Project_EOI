using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cameraMovement : MonoBehaviour
{

    public static cameraMovement instance;
    public int  mouseSensitivity = 120;
    public int maxVerticalAngle = 15;
    public int minVerticalAngle = 0;

    float verticalRotation = 0;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
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

    public void ShakeVertical(float magnitude, float duration)
    {
        StartCoroutine(ShakeVerticalCoroutine(magnitude, duration));
    }

    private IEnumerator ShakeVerticalCoroutine(float magnitude, float duration)
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float yOffset = Mathf.PerlinNoise(Time.time * 10, 0) * 2 - 1; // Efecto de sacudida usando Perlin Noise
            transform.localPosition = originalPosition + new Vector3(0, yOffset * magnitude, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition; // Volver a la posición original al final del "shake"
    }
}