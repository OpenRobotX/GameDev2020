using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public float speed = 2f;

     private void FixedUpdate() 
     {
         transform.Translate(Vector2.right * speed * Time.fixedDeltaTime * transform.localScale.y, Space.World);
     }

     private void OnTriggerEnter2D(Collider2D collision) 
     {
         if(collision.transform.name == "Enemy")
         {
             Destroy(collision.gameObject);
             Destroy(gameObject);
         }

         if(collision.transform.name == "Wall")
         {
             Destroy(gameObject);
         }
     }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
