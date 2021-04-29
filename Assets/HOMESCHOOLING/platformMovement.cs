using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
    public Transform firstPoint;
    public Transform secondPoint;

    public Transform target;

    void Start()
    {
        target.position = firstPoint.position;
    }

    
    void FixedUpdate()
    {
        if (transform.position == firstPoint.position)
        {
            target.position = secondPoint.position;
        }
        else if (transform.position == secondPoint.position)
        {
            target.position = firstPoint.position;
        }


        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.1f);
    }








    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(firstPoint.position, 0.2f);
        Gizmos.DrawSphere(secondPoint.position, 0.2f);
    }
}
