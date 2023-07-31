using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float projectileLifetime = 3f;
    public Rigidbody2D rb;
    void Update()
    {
        rb.velocity = Vector2.up * speed;
        Destroy(gameObject, projectileLifetime);
    }
}
