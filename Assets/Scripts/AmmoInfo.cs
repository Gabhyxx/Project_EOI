using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoInfo : MonoBehaviour
{
    private TMP_Text textComponent;
    public int ammoCharged;
    public int ammoUncharged;

    // Update is called once per frame
    void Update()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = ammoCharged + "/" + ammoUncharged;
    }
}
