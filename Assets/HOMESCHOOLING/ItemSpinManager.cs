using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpinManager : MonoBehaviour
{
    public float speed = 1.5f;

    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + speed, 0);
    }
}
