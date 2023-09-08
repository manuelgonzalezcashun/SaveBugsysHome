using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static event Action<Vector3> onPlayerMovement;
    [SerializeField] private float speed = 5f;
    private Vector2 moveDir;
    private Rigidbody2D rb;

    #region Player Input
    [SerializeField] private PlayerInput playerInput;
    private InputAction moveAction;
    #endregion
    void Awake()
    {
        moveAction = playerInput.actions["Movement"];
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveDir = moveAction.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir.x * speed, 0);
        onPlayerMovement?.Invoke(rb.velocity);
    }
}