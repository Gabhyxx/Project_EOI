using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartbeatScroll : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 startPosition; 
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RawImage>().material.mainTextureOffset = new Vector2(Time.time, 0);
        //transform.Translate(Vector3.left * speed);
    }
}
