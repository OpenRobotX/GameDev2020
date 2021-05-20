using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.transform.name == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
