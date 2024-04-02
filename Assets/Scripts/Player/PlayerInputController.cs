using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputController : IDisposable
    {
        private readonly InputControls _inputControls;

        public event Action SpellCastPressed;
        
        public Vector2 Movement { get; private set; }
        
        public PlayerInputController()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
            
            _inputControls.Gameplay.Movement.performed += MovementHandler;
            _inputControls.Gameplay.Movement.canceled += MovementHandler;
            
            _inputControls.Gameplay.SpellCast.performed += SpellUseHandler;
        }

        public void Dispose()
        {
            _inputControls.Gameplay.Movement.performed -= MovementHandler;
            _inputControls.Gameplay.Movement.canceled -= MovementHandler;
            
            _inputControls.Gameplay.SpellCast.performed -= SpellUseHandler;
        }

        private void SpellUseHandler(InputAction.CallbackContext context) => SpellCastPressed?.Invoke();

        private void MovementHandler(InputAction.CallbackContext context)
        {
            var movementValue = context.ReadValue<Vector2>();
            Movement = movementValue;
        }
    }
}