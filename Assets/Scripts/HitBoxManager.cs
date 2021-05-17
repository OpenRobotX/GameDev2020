using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{
    public GameObject test;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Enemy")
        {
            test.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 27), ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
    }

}
