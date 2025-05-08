using System;
using AI.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AI
{
    public class AIDirector
    {
        private const float SpawnFieldOutsideOffset = 0.2f;

        private readonly EnemyPool _enemyPool;
        private readonly EnemySettings _enemySettings;
        
        private int _currentZombiesCount;

        public AIDirector(EnemyPool enemyPool, EnemySettings enemySettings)
        {
            _enemyPool = enemyPool;
            _enemySettings = enemySettings;

            SpawnEnemies(_enemySettings.MaxEnemyAlive);
        }

        private void SpawnEnemies(int spawnCount)
        {
            for (var i = 0; i < spawnCount - 1; i++)
            {
                var enemyType = GetRandomEnemyType();
                var spawnPoint = GetRandomPoint();

                var enemy = _enemyPool.Get(enemyType, spawnPoint);

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
            var needToSpawnCount = _enemySettings.MaxEnemyAlive - _currentZombiesCount;
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

        private Vector3 GetRandomPoint()
        {
            var point = Vector3.zero;

            var randomAxisPosition = Random.value;
            var randomOutsideOffset = Random.Range(-SpawnFieldOutsideOffset, SpawnFieldOutsideOffset);
            if (randomOutsideOffset >= 0)
                randomOutsideOffset += 1;

            var isHorizontalSidePriority = Random.value > 0.5f;
            if (isHorizontalSidePriority)
            {
                point.x = randomAxisPosition;
                point.y = randomOutsideOffset;
            }
            else
            {
                point.x = randomOutsideOffset;
                point.y = randomAxisPosition;
            }

            point = Camera.main.ViewportToWorldPoint(point);
            point.y = 0;
            return point;
        }
    }
}