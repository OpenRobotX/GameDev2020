using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;

    private Animator anim;
    private AudioSource jumpSound;

    public Transform startPoint;

    public bool canClimb = false;
    public float gravity = 6f;

    //Missiles
    public Transform missilePoint;
    public GameObject missilePrefab;

    //PowerUps
    public float powerUpMoveSpeedValue = 1;
    private float powerUpMoveSpeedTime = 0;

    public float powerUpJumpHeightValue = 1;
    private float powerUpJumpHeightTime = 0;

    private float powerUpMaxTime = 5;
    

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();

        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
        transform.position = startPoint.position;
    }

    void FixedUpdate()
    {
        //PowerUp Countdown Timer
        if(powerUpMoveSpeedValue != 1)
        {
            powerUpMoveSpeedTime += Time.fixedDeltaTime;

            if(powerUpMoveSpeedTime >= powerUpMaxTime)
            {
                powerUpMoveSpeedValue = 1;
                powerUpMoveSpeedTime = 0;
            }
        }

        if(powerUpJumpHeightValue != 1)
        {
            powerUpJumpHeightTime += Time.fixedDeltaTime;

            if (powerUpJumpHeightTime >= powerUpMaxTime)
            {
                powerUpJumpHeightValue = 1;
                powerUpJumpHeightTime = 0;
            }
        }

        //Flip
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
        }

        //Move 
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed * Time.fixedDeltaTime * powerUpMoveSpeedValue;

        //Climb
        if (Input.GetAxisRaw("Vertical") != 0 && canClimb) 
        {
            transform.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0) * speed * Time.fixedDeltaTime;
        }
    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rig.velocity.y) < 0.001f && !canClimb)
        {
            jumpSound.Play();
            rig.AddForce(new Vector2(0, jumpForce * powerUpJumpHeightValue), ForceMode2D.Impulse);

        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject missileClone = (GameObject)Instantiate(missilePrefab, missilePoint.transform.position, transform.rotation);
            missileClone.transform.eulerAngles = new Vector3(180, 0, 90);
            missileClone.transform.localScale = new Vector3(1, transform.localScale.x, 1);
        }

        //ANIMATIONS
        anim.SetFloat("isWalking", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        if (Mathf.Abs(rig.velocity.y) < 0.001f)
        {
            anim.SetBool("isJumping", false);
        }
        else anim.SetBool("isJumping", true);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ladder") 
        {
            canClimb = true;
            rig.gravityScale = 0;
            rig.velocity = Vector3.zero;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Ladder")
        {
            canClimb = false;
            rig.gravityScale = gravity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "PlatformImages")
        {
            transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "PlatformImages")
        {
            transform.SetParent(null);
        }
    }
}
