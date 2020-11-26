using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Einkaufsliste / Variablen
    public float speed;

    private float xAxis;
    private float yAxis;

    public Transform playerTransform;
    public Vector3 offset;

    void Start()
    {// Wird einmal am start ausgeführt 
        xAxis = transform.position.x;
        yAxis = transform.position.y;
    }

    
    void Update()
    {// Wird pro Sekunde 60 mal ausgeführt 
        xAxis = xAxis + Input.GetAxis("Horizontal") * speed;
        yAxis = yAxis + Input.GetAxis("Vertical") * speed;

        //transform.position = new Vector3(xAxis, yAxis, transform.position.z);
        transform.position = playerTransform.position + offset;
    }
}
