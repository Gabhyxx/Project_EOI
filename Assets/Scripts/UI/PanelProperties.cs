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
        panel.color = new Color(0.3686f, 0.4549f, 0.3686f, 0.8314f);
    }

}
