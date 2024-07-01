using Code.Player;
using UnityEngine;

namespace Code.StateMachine.PlayerState
{
    public abstract class PlayerBaseState : IState {
        protected readonly PlayerController PlayerController;
        
        protected PlayerBaseState()
        {
            
        }
        
        protected PlayerBaseState(PlayerController playerController)
        {
            PlayerController = playerController;
        }

        public virtual void OnEnter()
        {
            // noop
        }

        public virtual void Update()
        {
            // noop
        }

        public virtual void FixedUpdate()
        {
            // noop
        }

        public virtual void OnExit()
        {
            // noop
        }
    }
}