using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public Slider healthBar;
    public GameObject deathPanel;

    void Start()
    {
        health = maxHealth;
    }

    
    void Update()
    {
        if(health <= 0 && healthBar.value != health)
        {
            health = 0;
            //Player dead
            GetComponent<PlayerManager>().enabled = false;
            GetComponent<Animator>().enabled = false;
            GetComponent<Rigidbody2D>().freezeRotation = false;
            GetComponent<Rigidbody2D>().AddTorque(5);
            deathPanel.SetActive(true);
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(healthBar.value != health)
        {
            healthBar.value = health;
        }
    }
}
