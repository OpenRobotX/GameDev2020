using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Einkaufsliste / Variablen
    public float speed;

    private float xAxis;
    private float yAxis;

    void Start()
    {// Wird einmal am start ausgeführt 
        xAxis = transform.position.x;
        yAxis = transform.position.y;
    }

    
    void Update()
    {// Wird pro Sekunde 60 mal ausgeführt 
        xAxis = xAxis + Input.GetAxis("Horizontal");
        yAxis = yAxis + Input.GetAxis("Vertical");

        transform.position = new Vector3(xAxis, yAxis, transform.position.z);
    }
}
