using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 moveDir;
    private Rigidbody2D rb;
    Animator walkAnim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        walkAnim = GetComponent<Animator>();
    }
    void Update()
    {
        if (PausingScript.gameIsPaused == false)
        {
            PlayerInputs();
        }
    }
    void FixedUpdate()
    {
        Move();
        if (moveDir.x != 0)
        {
            walkAnim.SetBool("isWalking", true);
        }
        else
        {
            walkAnim.SetBool("isWalking", false);
        }
    }
    void PlayerInputs()
    {
        float velX = Input.GetAxisRaw("Horizontal");
        moveDir = new Vector2(velX, 0);
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * speed, 0);
    }
}