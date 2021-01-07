using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool key1Collected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Key1")
        {
            key1Collected = true;
            collision.transform.gameObject.GetComponent<AudioSource>().Play();
            collision.transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (collision.transform.name == "Door1" && key1Collected)
        {
            collision.transform.gameObject.GetComponent<AudioSource>().Play();
            collision.transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            foreach (SpriteRenderer sprite in collision.transform.gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.enabled = false;
            }
        }
    }
}
