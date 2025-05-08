using UnityEngine;

namespace Players
{
    public class PlayerMovement
    {
        private readonly CharacterController _characterController;
        private readonly PlayerInput _input;

        private readonly float _speed;

        public PlayerMovement(CharacterController characterController, PlayerInput input,
            float speed)
        {
            _characterController = characterController;
            _input = input;
            _speed = speed;
        }

        public void Tick() => Move();

        private void Move()
        {
            var inputMovement = _input.Movement;
            var movement = new Vector3(inputMovement.x, 0, inputMovement.y);
            var motion = movement * (_speed * Time.deltaTime);

            RotateByMotion(movement);
            _characterController.Move(motion);
        }

        private void RotateByMotion(Vector3 movement)
        {
            var isStop = movement == Vector3.zero;
            _characterController.transform.rotation =
                isStop ? _characterController.transform.rotation : Quaternion.LookRotation(movement);
        }
    }
}