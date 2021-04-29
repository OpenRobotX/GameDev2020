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

            collision.GetComponent<StatsManager>().health = 0;
        }
    }
}
