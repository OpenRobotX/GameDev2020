using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneManager : MonoBehaviour
{
    public GameObject ui;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.GetComponent<StatsManager>().health -= collision.GetComponent<StatsManager>().maxHealth;
        }
    }
}
