using System;
using AI;
using SpellSystem;
using UI;
using UnityEngine;

namespace Player
{
    [SelectionBase]
    public class Player : MonoBehaviour, IAttackEnemyTarget
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private HealthSystem.HealthSystem healthSystem;
        [SerializeField] private SpellSlotUI spellSlotUI;

        private PlayerInputController _playerInputController;
        private PlayerMovement _playerMovement;

        private SpellController _spellController;
        
        public event Action Dead;

        public Vector3 Position => transform.position;

        private void Awake()
        {
            _playerInputController = new PlayerInputController();
            _playerMovement = new PlayerMovement(characterController, _playerInputController, settings.Speed);

            _spellController = new SpellController(settings.Spells, _playerInputController, spellSlotUI, this);
        }

        private void OnEnable()
        {
            healthSystem.Dead += HealthSystemDeadHandler;
            _playerInputController.Enable();
            _spellController.Enable();
        }

        private void OnDisable()
        {
            healthSystem.Dead -= HealthSystemDeadHandler;
            _playerInputController.Disable();
            _spellController.Disable();
        }

        private void Update() => _playerMovement.Tick();
        
        private void HealthSystemDeadHandler() => Dead?.Invoke();

        public void ApplyDamage(float damage) => healthSystem.ApplyDamage(damage);
    }
}