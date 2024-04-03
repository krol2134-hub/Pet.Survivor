using System;
using UnityEngine;

namespace HealthSystem
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private HealthSettings settings;

        private float _health;
        private bool _isDead;

        public event Action Dead;
        public event Action<float> HealthChanged;
        
        private float Health
        {
            get => _health;
            set
            {
                var previousHealth = _health;
                _health = Mathf.Clamp(value, 0f, settings.MaxHealth);

                var isChanged = !Mathf.Approximately(_health, previousHealth);
                if (isChanged)
                    HealthChanged?.Invoke(_health);
            }
        }

        public float MaxHealth => settings.MaxHealth;

        private void Awake() => Health = settings.MaxHealth;

        public void ApplyDamage(float damage)
        {
            if (_isDead)
                return;

            var finalDamage = damage - (damage * settings.Armor);
            Health -= finalDamage;

            if (Health <= 0)
            {
                _isDead = true;
                Dead?.Invoke();
            }
        }
    }
}