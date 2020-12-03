using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;

<<<<<<< HEAD
<<<<<<< HEAD
    private Rigidbody2D rig;
    private bool canClimb;

=======
>>>>>>> parent of f6672b1... Update PlayerMovement.cs
    void Start()
    {

<<<<<<< HEAD
    
    void Update()
    {
        //Jump
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rig.velocity.y) < 0.001f)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
=======
>>>>>>> parent of f6672b1... Update PlayerMovement.cs
=======
    void Start()
    {

>>>>>>> parent of f6672b1... Update PlayerMovement.cs
    }

    
    void FixedUpdate()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        //Flip
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
        }
        //Move 
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed * Time.fixedDeltaTime;
        //Climb
        if (Input.GetAxisRaw("Vertical") != 0 && canClimb)
        {
            transform.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0) * speed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ladder")
        {
            canClimb = true;
            rig.velocity = Vector3.zero;
            rig.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Ladder")
        {
            canClimb = false;
            rig.gravityScale = 7;
        }
=======
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * jumpForce, 0) * speed * Time.fixedDeltaTime;
>>>>>>> parent of f6672b1... Update PlayerMovement.cs
=======
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * jumpForce, 0) * speed * Time.fixedDeltaTime;
>>>>>>> parent of f6672b1... Update PlayerMovement.cs
    }
}
