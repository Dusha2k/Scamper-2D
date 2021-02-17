using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float moovespeed = 1f;

    public float offset;
    private Vector2 startposition;
    private float newxposition;
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newxposition = Mathf.Repeat(Time.time * -moovespeed, offset);
        transform.position = startposition + Vector2.up * newxposition;
          
    }
}
