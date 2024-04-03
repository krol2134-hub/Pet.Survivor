using UnityEngine;

namespace AI.Enemies
{
    [CreateAssetMenu(menuName = "Nekki.TestTask/Enemy Settings", fileName = "New Enemy Settings")]
    public class EnemySettings : ScriptableObject
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