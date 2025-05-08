using HealthSystem;
using UnityEngine;

namespace AI.Enemies
{
    [CreateAssetMenu(menuName = "Pet.Survivor/Enemy Settings", fileName = "EnemySettings")]
    public class EnemySettings : HealthSettings
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private float damage = 10f;
        [SerializeField] private float radiusForDamageTarget = 1.2f;
        [SerializeField] private float speed = 2.4f;

        public EnemyType Type => type;
        public float Damage => damage;
        public float RadiusForDamageTarget => radiusForDamageTarget;
        public float Speed => speed;
    }
}