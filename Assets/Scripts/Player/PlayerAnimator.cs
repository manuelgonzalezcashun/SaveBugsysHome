using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    private void OnEnable()
    {
        PlayerController.onPlayerMovement += PlayerMoveAnim;
    }
    private void OnDisable()
    {
        PlayerController.onPlayerMovement -= PlayerMoveAnim;
    }
    private void PlayerMoveAnim(Vector3 move)
    {
        if (move.x != 0)
        {
            playerAnimator.Play("BugsyWalk");
        }
        else
        {
            playerAnimator.Play("BugsyIdle");
        }
    }
}
