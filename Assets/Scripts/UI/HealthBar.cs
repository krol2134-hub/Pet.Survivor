using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthSystem.HealthSystem healthSystem;
        [SerializeField] private Slider slider;

        private void Start()
        {
            slider.maxValue = healthSystem.MaxHealth;
            slider.value = healthSystem.MaxHealth;
        }
        
        private void OnEnable()
        {
            healthSystem.HealthChanged += HealthChangedHandler;
        }

        private void OnDisable()
        {
            healthSystem.HealthChanged -= HealthChangedHandler;
        }

        private void HealthChangedHandler(float currentHealth) => slider.value = currentHealth;
    }
}
