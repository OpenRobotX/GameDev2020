using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeController : MonoBehaviour
{
    public float distance;
    public float speed = 2f;

    
    private void FixedUpdate() 
    {
        distance = transform.position.x - GameObject.Find("Player").GetComponent<Transform>().position.x;
        
        if(Mathf.Abs(distance) < 8f && Mathf.Abs(distance) > 0.5f)
        {
            transform.localScale = new Vector3(Mathf.Sign(distance), transform.localScale.y, transform.localScale.z);

            transform.position += new Vector3(1 * -Mathf.Sign(distance), 0, 0) * speed * Time.fixedDeltaTime;
        }
    }
}
