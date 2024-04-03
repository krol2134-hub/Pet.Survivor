using AI.Enemies;
using UnityEngine;

namespace AI
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy[] prefabs;
        
        public Enemy CreateEnemy(EnemyType type, Vector3 position, IAttackEnemyTarget attackTarget)
        {
            foreach (var prefab in prefabs)
            {
                var isTargetType = prefab.Type == type;
                if (!isTargetType) 
                    continue;
                
                var enemy = Instantiate(prefab, position, Quaternion.identity);
                enemy.Initialize(attackTarget);
                return enemy;
            }

            return null;
        }
    }
}