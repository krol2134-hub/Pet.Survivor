using UnityEngine;

namespace Enemies
{
    public interface IAttackEnemyTarget
    {
        public Vector3 Position { get; }
        public float RadiusForAttack { get; }

        public void ApplyDamage(float damage);
    }
}