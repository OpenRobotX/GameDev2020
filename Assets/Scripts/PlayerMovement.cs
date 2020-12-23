using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;
    private bool canClimb;

    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Flip
        if (Input.GetAxisRaw("Horizontal") != 0)
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

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rig.velocity.y) < 0.001f)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        //ANIMATIONS
        anim.SetFloat("isWalking", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if(Mathf.Abs(rig.velocity.y) < 0.001f)
        {
            anim.SetBool("isJumping", false);
        }else anim.SetBool("isJumping", true);

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
        canClimb = false;
        rig.gravityScale = 7;
    }

    
}
