using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] Light flashLight;

    private void Awake()
    {
        flashLight = GetComponent<Light>();
    }

    private void Start()
    {
        flashLight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            flashLight.enabled = !flashLight.enabled;
        }
    }
}
