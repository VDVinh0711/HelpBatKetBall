using Code.Player;
using UnityEngine;

namespace Code.StateMachine.PlayerState
{
    public class PlayerFlyingState : PlayerBaseState
    {
        public PlayerFlyingState(PlayerController playerController) : base(playerController)
        {
        }

        public override void FixedUpdate()
        {
            PlayerController.HandleJump();
            // Debug.Log("Flying");
        }
    }
}