using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputController
    {
        private readonly InputControls _inputControls;

        public event Action SpellCastPressed;
        public event Action SpellPreviousPressed;
        public event Action SpellNextPressed;
        
        public Vector2 Movement { get; private set; }
        
        public PlayerInputController()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
        }

        public void Enable()
        {
            _inputControls.Gameplay.Movement.performed += MovementHandler;
            _inputControls.Gameplay.Movement.canceled += MovementHandler;
            
            _inputControls.Gameplay.SpellCast.performed += SpellUseHandler;
            _inputControls.Gameplay.SpellPrevious.performed += SpellPreviousHandler;
            _inputControls.Gameplay.SpellNext.performed += SpellNextHandler;
        }

        public void Disable()
        {
            _inputControls.Gameplay.Movement.performed -= MovementHandler;
            _inputControls.Gameplay.Movement.canceled -= MovementHandler;
            
            _inputControls.Gameplay.SpellCast.performed -= SpellUseHandler;
            _inputControls.Gameplay.SpellPrevious.performed -= SpellPreviousHandler;
            _inputControls.Gameplay.SpellNext.performed -= SpellNextHandler;
        }

        private void MovementHandler(InputAction.CallbackContext context)
        {
            var movementValue = context.ReadValue<Vector2>();
            Movement = movementValue;
        }

        private void SpellUseHandler(InputAction.CallbackContext context) => SpellCastPressed?.Invoke();

        private void SpellPreviousHandler(InputAction.CallbackContext context) => SpellPreviousPressed?.Invoke();

        private void SpellNextHandler(InputAction.CallbackContext context) => SpellNextPressed?.Invoke();
    }
}