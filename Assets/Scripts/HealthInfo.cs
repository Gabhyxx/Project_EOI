using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthInfo : MonoBehaviour
{
    private TMP_Text textComponent;
    public int health;

    // Update is called once per frame
    void Update()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = health+"%";
    }
}
