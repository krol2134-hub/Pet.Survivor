using UnityEngine;

namespace AI
{
    public interface IAttackEnemyTarget
    {
        public Vector3 Position { get; }

        public void ApplyDamage(float damage);
    }
}