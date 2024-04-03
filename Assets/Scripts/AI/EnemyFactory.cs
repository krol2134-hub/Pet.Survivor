using AI.Enemies;
using UnityEngine;

namespace AI
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy[] prefabs;

        private IAttackEnemyTarget _attackTarget;
        
        public void Initialize(IAttackEnemyTarget attackTarget) => _attackTarget = attackTarget;

        public Enemy CreateEnemy(EnemyType type, Vector3 position, Quaternion rotation)
        {
            foreach (var prefab in prefabs)
            {
                var isTargetType = prefab.Type == type;
                if (!isTargetType) 
                    continue;
                
                var enemy = Instantiate(prefab, position, rotation);
                enemy.Initialize(_attackTarget);
                return enemy;
            }

            return null;
        }
    }
}