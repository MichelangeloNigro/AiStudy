using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody rb;
    public float speed;
    protected float x;
    protected float y;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Movex(InputActionEventData data)
    {
        rb.position += new Vector3(0, 0, x*Time.deltaTime*speed);
        
    }

    public void Movey(InputActionEventData data)
    {
        rb.position += new Vector3( y*Time.deltaTime*speed,0,0);
    }

    public void Shoot()
    {
        
    }

    public void Jump()
    {
        
    }

    
}
