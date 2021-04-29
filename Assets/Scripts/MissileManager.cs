using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{

    public float speed = 2f;
    private Vector2 velocity = Vector2.right;

    private void FixedUpdate()
    {
        transform.Translate(velocity * speed * Time.fixedDeltaTime * transform.localScale.y, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
