using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTarget : MonoBehaviour
{
    private GameObject target;
    public float speed;
    void Start()
    {
        target = GameObject.Find("DestroyFloor");

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
