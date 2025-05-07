using UnityEngine;

namespace Players
{
    public class PlayerMovement
    {
        private readonly CharacterController _characterController;
        private readonly PlayerInputController _inputController;

        private readonly float _speed;

        public PlayerMovement(CharacterController characterController, PlayerInputController inputController,
            float speed)
        {
            _characterController = characterController;
            _inputController = inputController;
            _speed = speed;
        }

        public void Tick() => Move();

        private void Move()
        {
            var inputMovement = _inputController.Movement;
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