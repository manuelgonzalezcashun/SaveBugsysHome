using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Update()
    {
        rb.velocity = Vector2.up * speed; 
    }
}
