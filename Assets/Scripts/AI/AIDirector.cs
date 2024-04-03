using System;
using AI.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AI
{
    public class AIDirector : MonoBehaviour
    {
        [SerializeField] private int maxEnemyCount = 10;
        [SerializeField] private Transform[] spawnPoints;

        private int _currentZombiesCount;
        
        private EnemyPool _enemyPool;

        public void Initialize(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
            
            SpawnEnemies(maxEnemyCount);
        }

        private void SpawnEnemies(int spawnCount)
        {
            for (var i = 0; i < spawnCount - 1; i++)
            {
                var enemyType = GetRandomEnemyType();
                var spawnPoint = GetRandomSpawnPoint();

                var enemy = _enemyPool.Get(enemyType, spawnPoint.position, spawnPoint.rotation);
                
                enemy.Dead += EnemyDeadHandler;

                _currentZombiesCount++;
            }
        }

        private void EnemyDeadHandler(Enemy enemy)
        {
            _currentZombiesCount--;
            enemy.Dead -= EnemyDeadHandler;

            TrySpawnZombies();
        }

        private void TrySpawnZombies()
        {
            var needToSpawnCount = maxEnemyCount - _currentZombiesCount;
            if (needToSpawnCount > 0)
                SpawnEnemies(needToSpawnCount);
        }

        //TODO Extension to random pick from enum
        private EnemyType GetRandomEnemyType()
        {
            var types = Enum.GetValues(typeof(EnemyType));
            var randomIndex = Random.Range(0, types.Length);
            var randomEnemyType = (EnemyType)types.GetValue(randomIndex);
            return randomEnemyType;
        }
        
        private Transform GetRandomSpawnPoint()
        {
            //TODO Extension to random pick
            var randomIndex = Random.Range(0, spawnPoints.Length);
            return spawnPoints[randomIndex];
        }
    }
}
