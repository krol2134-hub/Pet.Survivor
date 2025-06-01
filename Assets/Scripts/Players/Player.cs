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
        
        private SpellController _spellController;

        public event Action Dead;

        public Vector3 Position => transform.position;

        private void Awake()
        {
            _spellController = new SpellController(settings.Spells, spellSlotUI, transform);
        }

        private void OnEnable()
        {
            healthSystem.Dead += HealthSystemDeadHandler;
        }

        private void OnDisable()
        {
            healthSystem.Dead -= HealthSystemDeadHandler;
        }

        private void Update()
        {
            _spellController.Update();
        }

        private void HealthSystemDeadHandler() => Dead?.Invoke();

        public void ApplyDamage(float damage) => healthSystem.ApplyDamage(damage);
    }
}