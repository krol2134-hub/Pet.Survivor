using System;
using AI;
using SpellSystem;
using UI;
using UnityEngine;

namespace Players
{
    [SelectionBase]
    public class Player : MonoBehaviour, IAttackEnemyTarget
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private HealthSystem.HealthSystem healthSystem;
        [SerializeField] private SpellSlotUI spellSlotUI;

        private PlayerInput _playerInput;
        private PlayerMovement _playerMovement;

        private SpellController _spellController;

        public event Action Dead;

        public Vector3 Position => transform.position;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerMovement = new PlayerMovement(characterController, _playerInput, settings.Speed);

            _spellController = new SpellController(settings.Spells, spellSlotUI, transform);
        }

        private void OnEnable()
        {
            _playerInput.Enable();

            healthSystem.Dead += HealthSystemDeadHandler;
        }

        private void OnDisable()
        {
            _playerInput.Disable();

            healthSystem.Dead -= HealthSystemDeadHandler;
        }

        private void Update()
        {
            _playerMovement.Tick();
            _spellController.Update();
        }

        private void HealthSystemDeadHandler() => Dead?.Invoke();

        public void ApplyDamage(float damage) => healthSystem.ApplyDamage(damage);
    }
}