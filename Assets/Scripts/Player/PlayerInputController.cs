using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputController : IDisposable
    {
        private readonly InputControls _inputControls;

        public Vector2 Movement { get; private set; }
        
        public PlayerInputController()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
            
            _inputControls.Gameplay.Movement.performed += MovementHandler;
            _inputControls.Gameplay.Movement.canceled += MovementHandler;
        }

        public void Dispose()
        {
            _inputControls.Gameplay.Movement.performed -= MovementHandler;
            _inputControls.Gameplay.Movement.canceled -= MovementHandler;
        }
        
        private void MovementHandler(InputAction.CallbackContext context)
        {
            var movementValue = context.ReadValue<Vector2>();
            Movement = movementValue;
        }
    }
}