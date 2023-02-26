using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    void Start()
    {
        if (gameObject.transform.position.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else 
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
