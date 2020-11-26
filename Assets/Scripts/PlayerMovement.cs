using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;

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
    }
}
