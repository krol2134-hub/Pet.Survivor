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
        
        private Player.Player _player;
        private EnemyFactory _enemyFactory;

        public void Initialize(Player.Player player, EnemyFactory enemyFactory)
        {
            _player = player;
            _enemyFactory = enemyFactory;
            
            SpawnEnemies(maxEnemyCount);
        }

        private void SpawnEnemies(int spawnCount)
        {
            for (var i = 0; i < spawnCount - 1; i++)
            {
                var enemyType = GetRandomEnemyType();
                var position = GetRandomSpawnPosition();

                var enemy = _enemyFactory.CreateEnemy(enemyType, position);
                enemy.Initialize(_player);
                
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

        private EnemyType GetRandomEnemyType()
        {
            var types = Enum.GetValues(typeof(EnemyType));
            var randomIndex = Random.Range(0, types.Length);
            var randomEnemyType = (EnemyType)types.GetValue(randomIndex);
            return randomEnemyType;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            var randomIndex = Random.Range(0, spawnPoints.Length);
            return spawnPoints[randomIndex].position;
        }
    }
}
