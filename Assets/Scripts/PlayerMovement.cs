﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;
    private bool canClimb;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rig.velocity.y) < 0.001f)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed * Time.fixedDeltaTime;
        if (Input.GetAxisRaw("Vertical") != 0 && canClimb)
        {
            transform.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0) * speed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canClimb = true;
        rig.velocity = Vector3.zero;
        rig.gravityScale = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canClimb = false;
        rig.gravityScale = 7;
    }
}
