using AI.Enemies;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "Pet.Survivor/EnemySettings", fileName = "EnemySettings")]
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private int poolSize = 10;
        [SerializeField] private int maxEnemyAlive = 10;
        [SerializeField] private Enemy[] prefabs;

        public int MaxEnemyAlive => maxEnemyAlive;
        public int PoolSize => poolSize;
        public Enemy[] Prefabs => prefabs;
    }
}