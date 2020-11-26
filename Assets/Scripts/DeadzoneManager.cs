using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Debug.Log("Player is dead");
            collision.GetComponent<PlayerMovement>().enabled = false;
            collision.GetComponent<Rigidbody2D>().freezeRotation = false;
            collision.GetComponent<Rigidbody2D>().AddTorque(5);
        }
    }
}
