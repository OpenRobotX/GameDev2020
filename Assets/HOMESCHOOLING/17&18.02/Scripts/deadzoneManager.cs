using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadzoneManager : MonoBehaviour
{
    public GameObject ui;

    private void Start()
    {
        ui.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Debug.Log("Player is dead");
            collision.GetComponent<PlayerManager>().enabled = false;
            collision.GetComponent<Animator>().enabled = false;
            collision.GetComponent<Rigidbody2D>().freezeRotation = false;
            collision.GetComponent<Rigidbody2D>().AddTorque(5);
            ui.SetActive(true);
        }
    }
}
