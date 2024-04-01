using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed = 2f;

        private PlayerMovement _playerMovement;
        private PlayerInputController _playerInputController;
        
        private void Awake()
        {
            _playerInputController = new PlayerInputController();
            _playerMovement = new PlayerMovement(characterController, _playerInputController, speed);
        }

        private void Update() => _playerMovement.Tick();
    }
}