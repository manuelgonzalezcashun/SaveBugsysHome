using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool onPressed = false;
    private float velX;
    public float speed = 2f;
    Animator walkAnim;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        walkAnim = GetComponent<Animator>();
    }
    void Update()
    {
        if (onPressed && velX == -1)
        {
            rb.velocity = new Vector2(velX * speed, 0);
        }
        else if (onPressed && velX == 1)
        {
            rb.velocity = new Vector2(velX * speed, 0);
        }
        if (velX != 0)
        {
            walkAnim.SetBool("isWalking", true);
        }
        else
        {
            walkAnim.SetBool("isWalking", false);
        }
    }
    public void SetBoolTrue()
    {
        onPressed = true;
    }
    public void SetBoolFalse()
    {
        onPressed = false;
        velX = 0;
    }
    public void MoveRight()
    {
        velX = 1;
    }
    public void MoveLeft()
    {
        velX = -1;
    }
}
