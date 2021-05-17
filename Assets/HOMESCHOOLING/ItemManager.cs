using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject myPlayer;

    public bool keyCollected = false;
    public AudioSource collectSound;
    public AudioSource doorSound;
    public AudioSource powerUpCollectionSound;

    private void Start()
    {
        myPlayer = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Key")
        {
            
            keyCollected = true;
            collectSound.Play();
            collision.transform.gameObject.SetActive(false);
        }

        if(collision.transform.name == "Door" && keyCollected == true)
        {
            doorSound.Play();
            collision.transform.gameObject.SetActive(false);
        }

        if(collision.transform.name == "PowerUp_MovementSpeed")
        {
            myPlayer.GetComponent<PlayerManager>().powerUpMovementSpeedValue = 3f;
            powerUpCollectionSound.Play();
            collision.transform.gameObject.SetActive(false);
        }

        if (collision.transform.name == "PowerUp_JumpHeight")
        {
            myPlayer.GetComponent<PlayerManager>().powerUpJumpHeightValue = 1.5f;
            powerUpCollectionSound.Play();
            collision.transform.gameObject.SetActive(false);
        }
    }
}
