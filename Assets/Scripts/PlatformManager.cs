using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;

    private bool moveLeft;


    void FixedUpdate()
    {
        if (moveLeft)
        {
            transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
            if(transform.position.x <= leftPoint.transform.position.x)
            {
                moveLeft = false;
            }
        }
        if (!moveLeft)
        {
            transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
            if (transform.position.x >= rightPoint.transform.position.x)
            {
                moveLeft = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(leftPoint.position, 0.2f);
        Gizmos.DrawSphere(rightPoint.position, 0.2f);
    }
}
