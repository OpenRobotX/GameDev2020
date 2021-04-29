using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject myPlayer;

    public bool keyCollected = false;
    public AudioSource keyCollectSound;
    public AudioSource doorOpenSound;
    public AudioSource powerUpCollectSound;

    private void Start()
    {
        myPlayer = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.transform.name == "Key")
        {
            keyCollected = true;
            keyCollectSound.Play();
            collision.gameObject.SetActive(false);
        }

        if(collision.transform.name == "Door" && keyCollected)
        {
            doorOpenSound.Play();
            collision.gameObject.SetActive(false);
            keyCollected = false;
        }

        if (collision.transform.name == "PowerUp_MoveSpeed")
        {
            myPlayer.GetComponent<PlayerManager>().powerUpMoveSpeedValue = 3;
            powerUpCollectSound.Play();
            collision.gameObject.SetActive(false);
        }

        if (collision.transform.name == "PowerUp_JumpHeight")
        {
            myPlayer.GetComponent<PlayerManager>().powerUpJumpHeightValue = 1.5f;
            powerUpCollectSound.Play();
            collision.gameObject.SetActive(false);
        }
    }
}
