using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAnimation : MonoBehaviour
{

    public float speed = 1.5f;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + speed, 0);
    }
}
