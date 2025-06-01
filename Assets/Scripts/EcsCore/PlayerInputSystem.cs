using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EcsCore
{
    public sealed class PlayerInputSystem : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

        private readonly InputControls _inputControls;

        private Vector2 _movement;

        public PlayerInputSystem()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
        }

        public void Init()
        {
            _inputControls.Gameplay.Movement.performed += MovementHandler;
            _inputControls.Gameplay.Movement.canceled += MovementHandler;
        }

        public void Destroy()
        {
            _inputControls.Gameplay.Movement.performed -= MovementHandler;
            _inputControls.Gameplay.Movement.canceled -= MovementHandler;
        }

        public void Run()
        {
            SaveDirectionInput();
        }

        private void SaveDirectionInput()
        {
            foreach (var index in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get2(index);
                directionComponent.Direction = _movement;
            }
        }

        private void MovementHandler(InputAction.CallbackContext context)
        {
            var movementValue = context.ReadValue<Vector2>();
            _movement = movementValue;
        }
    }
}