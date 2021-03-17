using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;

    public Transform target;
    public Vector3 distance;

    private void Start()
    {
        target.position = leftPoint.position;
    }
    void FixedUpdate()
    {
        distance = transform.position - target.position;

        if(distance == Vector3.zero && transform.position == leftPoint.position)
        {
            target.position = rightPoint.position;
        }
        else if (distance == Vector3.zero && transform.position == rightPoint.position)
        {
            target.position = leftPoint.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(leftPoint.position, 0.2f);
        Gizmos.DrawSphere(rightPoint.position, 0.2f);
    }
}
