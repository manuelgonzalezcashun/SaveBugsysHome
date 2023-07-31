using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action<Vector3> onPlayerMovement;
    [SerializeField] private float speed = 5f;

    private Vector2 moveDir;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerInputs();
    }
    void FixedUpdate()
    {
        Move();
    }
    void PlayerInputs()
    {
        float velX = Input.GetAxisRaw("Horizontal");
        moveDir = new Vector2(velX, 0);
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * speed, 0);
        onPlayerMovement?.Invoke(rb.velocity);
    }
}