using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelProperties : MonoBehaviour
{
    Image panel;

    void Start()
    {
        panel = GetComponent<Image>();
        panel.color = Color.black;
    }

}
