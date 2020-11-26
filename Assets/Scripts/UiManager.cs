using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void exitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void restartGame()
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("StartPoint").GetComponent<Transform>().position;

        GameObject.Find("Player").GetComponent<Rigidbody2D>().SetRotation(0);
        GameObject.Find("Player").GetComponent<Rigidbody2D>().freezeRotation = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("PauseMenu").SetActive(false);
    }
}
