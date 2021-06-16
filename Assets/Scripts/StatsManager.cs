using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public Slider healthbar;
    public GameObject deathPanel;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0 && healthbar.value != health)
        {
            health = 0;

            if(transform.name == "Player")
            {
                Debug.Log("Player is dead");
                GetComponent<PlayerManager>().enabled = false;
                GetComponent<Animator>().enabled = false;
                GetComponent<Rigidbody2D>().freezeRotation = false;
                GetComponent<Rigidbody2D>().AddTorque(5);
                deathPanel.SetActive(true);
            }
            if(transform.tag == "Enemy")
            {
                Debug.Log("Enemy is dead");
                Destroy(gameObject);
            }
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if(healthbar.value != health)
        {
            healthbar.value = health;
        }
    }
}
