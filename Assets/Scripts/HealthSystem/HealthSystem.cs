using System;
using UnityEngine;

namespace HealthSystem
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField, Range(0f, 1f)] private float armor = 0.5f;

        private float _health;
        private bool _isDead;

        public event Action Dead;
        
        private float Health
        {
            get => _health;
            set => _health = Mathf.Clamp(value, 0f, maxHealth);
        }
        
        private void Awake() => Health = maxHealth;

        public void ApplyDamage(float damage)
        {
            if (_isDead)
                return;

            var finalDamage = damage - (damage * armor);
            Health -= finalDamage;

            if (Health <= 0)
            {
                _isDead = true;
                Dead?.Invoke();
            }
        }
    }
}