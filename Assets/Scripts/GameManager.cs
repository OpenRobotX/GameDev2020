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
            GameObject.Destroy(collision.transform.gameObject);
        }
        if (collision.transform.name == "Door1" && key1Collected)
        {
            GameObject.Destroy(collision.transform.gameObject);
        }
    }
}
