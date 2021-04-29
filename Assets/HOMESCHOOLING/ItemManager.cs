using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool keyCollected = false;
    public AudioSource collectSound;
    public AudioSource doorSound;
    public AudioSource powerupSound;


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
    }
}
