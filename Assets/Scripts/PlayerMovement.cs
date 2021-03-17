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
    private AudioSource jumpSound;

    public Transform startPoint;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();

        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
        //transform.position = startPoint.position;
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
            jumpSound.Play();
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
        if(collision.name == "CheckPoint")
        {
            GameObject.Find("StartPoint").GetComponent<Transform>().position = transform.position;
            collision.transform.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Ladder")
        {
            canClimb = false;
            rig.gravityScale = 6;
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.name == "Platform")
        {
            transform.SetParent(coll.gameObject.transform);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        transform.SetParent(null);
    }
}
