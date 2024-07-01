using Code.Player;
using UnityEngine;

namespace Code.StateMachine.PlayerState
{
    public class PlayerStrafeState : PlayerBaseState
    {
        public PlayerStrafeState(PlayerController playerController) : base(playerController)
        {
        }

        public override void FixedUpdate()
        {
            PlayerController.HandleStrafe();
            // Debug.Log("Strafing");
        }
        
        public override void OnExit()
        {
            PlayerController.ResetVelocity();
        }
    }
}