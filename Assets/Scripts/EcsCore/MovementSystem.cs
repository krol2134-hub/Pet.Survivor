using Leopotam.Ecs;
using UnityEngine;

namespace EcsCore
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CharacterMoveComponent, DirectionComponent> _characterMoveFilter = null;
        
        public void Run()
        {
            MoveCharacters();
        }

        private void MoveCharacters()
        {
            foreach (var i in _characterMoveFilter)
            {
                ref var characterMoveComponent = ref _characterMoveFilter.Get1(i);
                ref var directionComponent = ref _characterMoveFilter.Get2(i);

                ref var characterController = ref characterMoveComponent.CharacterController;
                ref var direction = ref directionComponent.Direction;
                
                var movement = CalculateMotionDirection(direction, characterMoveComponent, out var motion);

                RotateByMotion(characterController, movement);
                characterController.Move(motion);
            }
        }

        private static Vector3 CalculateMotionDirection(Vector2 direction, CharacterMoveComponent characterMoveComponent,
            out Vector3 motion)
        {
            var movement = new Vector3(direction.x, 0, direction.y);
            motion = movement * (characterMoveComponent.Speed * Time.deltaTime);
            return movement;
        }

        private void RotateByMotion(CharacterController characterController, Vector3 movement)
        {
            var isStop = movement == Vector3.zero;
            characterController.transform.rotation =
                isStop ? characterController.transform.rotation : Quaternion.LookRotation(movement);
        }
    }
}