using UnityEngine;

namespace HealthSystem
{
    [CreateAssetMenu(menuName = "Pet.Survivor/Health Settings", fileName = "Health Settings")]
    public class HealthSettings : ScriptableObject
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField, Range(0f, 1f)] private float armor = 0.5f;

        public float MaxHealth => maxHealth;
        public float Armor => armor;
    }
}