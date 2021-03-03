using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void exitGame()
    {
        Application.Quit();
    }
    public void restartGame()
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GameObject.Find("Player").GetComponent<Transform>().localScale = Vector3.one;
        GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("StartPoint").GetComponent<Transform>().position;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;

        GameObject.Find("Player").GetComponent<Rigidbody2D>().SetRotation(0);
        GameObject.Find("Player").GetComponent<Rigidbody2D>().freezeRotation = true;

        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;

        GameObject.Find("Canvas").SetActive(false);
        
    }
}
