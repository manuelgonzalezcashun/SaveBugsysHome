using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    #region Animation States
    private const string WALK_ANIM = "BugsyWalk";
    private const string IDLE_ANIM = "BugsyIdle";
    #endregion
    [SerializeField] private Animator playerAnimator;

    #region Event Listeners
    private void OnEnable()
    {
        PlayerController.onPlayerMovement += PlayerMoveAnim;
    }
    private void OnDisable()
    {
        PlayerController.onPlayerMovement -= PlayerMoveAnim;
    }
    #endregion
    private void PlayerMoveAnim(Vector3 move)
    {
        if (move.x != 0)
        {
            playerAnimator.Play(WALK_ANIM);
        }
        else
        {
            playerAnimator.Play(IDLE_ANIM);
        }
    }
}
