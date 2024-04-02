using SpellSystem;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private SpellBase[] spells;
        [SerializeField] private float speed = 2f;

        private PlayerInputController _playerInputController;
        private PlayerMovement _playerMovement;

        private SpellController _spellController;

        private void Awake()
        {
            _playerInputController = new PlayerInputController();
            _playerMovement = new PlayerMovement(characterController, _playerInputController, speed);

            _spellController = new SpellController(spells, _playerInputController, transform);
        }

        private void Update() => _playerMovement.Tick();
    }
}