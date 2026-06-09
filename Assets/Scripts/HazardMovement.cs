using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMovement : MonoBehaviour
{
    public float distance = 5f;  
    public float speed = 2f;      

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + new Vector3(movement, 0, 0);
    }
}