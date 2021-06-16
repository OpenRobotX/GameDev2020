using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
    public Transform firstPoint;
    public Transform secondPoint;

    public Transform targetPoint;
    private Vector3 distance;

    void Start()
    {
        targetPoint.position = firstPoint.position;
    }

    
    void FixedUpdate()
    {
        distance = transform.position - targetPoint.position;

        if(distance == Vector3.zero && transform.position == firstPoint.position)
        {
            targetPoint.position = secondPoint.position;
        }
        else if(distance == Vector3.zero && transform.position == secondPoint.position)
        {
            targetPoint.position = firstPoint.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, 0.1f);
    }


    private void OnDrawGizmos() 
    {
        Gizmos.DrawSphere(firstPoint.position, 0.2f);
        Gizmos.DrawSphere(secondPoint.position, 0.2f);
    }
}
