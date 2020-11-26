﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    void Start()
    {

    }

    
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * jumpForce, 0) * speed * Time.fixedDeltaTime;
    }
}