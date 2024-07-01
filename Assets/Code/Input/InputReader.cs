using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static PlayerInputActions;

namespace Code.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader")]
    public class InputReader : ScriptableObject, IPlayerActions
    {
        public event UnityAction<bool> TouchPress = delegate { }; 
        
        private PlayerInputActions _inputActions;

        public Vector2 TouchPosition => _inputActions.Player.TouchPosition.ReadValue<TouchState>().position;

        private void OnEnable()
        {
            if (_inputActions is null)
            {
                _inputActions = new PlayerInputActions();
                _inputActions.Player.SetCallbacks(this);
            }
        }

        public void EnablePlayerActions() => _inputActions.Enable();

        public void OnTouchPress(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    TouchPress.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    TouchPress.Invoke(false);
                    break;
            }
        }

        public void OnTouchPosition(InputAction.CallbackContext context)
        {
            // noop
        }
    }
}
