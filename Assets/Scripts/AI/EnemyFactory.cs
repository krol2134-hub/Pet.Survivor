using AI.Enemies;
using UnityEngine;

namespace AI
{
    public class EnemyFactory
    {
        private readonly IAttackEnemyTarget _attackTarget;
        private readonly EnemySettings _settings;

        public EnemyFactory(IAttackEnemyTarget attackTarget, EnemySettings settings)
        {
            _attackTarget = attackTarget;
            _settings = settings;
        }
        
        public Enemy CreateEnemy(EnemyType type, Vector3 position, Quaternion rotation)
        {
            foreach (var prefab in _settings.Prefabs)
            {
                var isTargetType = prefab.Type == type;
                if (!isTargetType)
                    continue;

                var enemy = Object.Instantiate(prefab, position, rotation);
                enemy.Initialize(_attackTarget);
                return enemy;
            }

            return null;
        }
    }
}