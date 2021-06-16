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
        if(collision.gameObject.name == "Player")
        {
            collision.GetComponent<StatsManager>().health -= collision.GetComponent<StatsManager>().maxHealth;
        }
    }
}
