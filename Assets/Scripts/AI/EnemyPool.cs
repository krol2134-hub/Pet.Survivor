using System;
using System.Collections.Generic;
using AI.Enemies;
using Extensions;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace AI
{
    public class EnemyPool
    {
        private readonly EnemyFactory _factory;
        private readonly EnemySettings _enemySettings;
        
        private readonly Dictionary<EnemyType, ObjectPool<Enemy>> _pools = new();

        public EnemyPool(EnemyFactory factory, EnemySettings enemySettings)
        {
            _factory = factory;
            _enemySettings = enemySettings;

            InitializePools();
        }

        private void InitializePools()
        {
            foreach (EnemyType enemyType in Enum.GetValues(typeof(EnemyType)))
                RegisterPool(enemyType);
        }

        private void RegisterPool(EnemyType type)
        {
            var newPool = new ObjectPool<Enemy>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy, false,
                defaultCapacity: _enemySettings.PoolSize);
            newPool.Prewarm(_enemySettings.PoolSize);
            _pools.Add(type, newPool);

            return;

            Enemy CreateFunc() => _factory.CreateEnemy(type, Vector3.zero, Quaternion.identity);

            void ActionOnGet(Enemy enemy)
            {
                enemy.gameObject.SetActive(true);
                enemy.ResetData();
            }

            void ActionOnRelease(Enemy enemy) => enemy.gameObject.SetActive(false);

            void ActionOnDestroy(Enemy enemy) => Object.Destroy(enemy.gameObject);
        }

        public Enemy Get(EnemyType type, Vector3 position)
        {
            var pool = _pools[type];
            var zombie = pool.Get();

            zombie.transform.position = position;
            zombie.Dead += ReturnToPool;

            return zombie;

            void ReturnToPool(Enemy enemy)
            {
                pool.Release(enemy);
                enemy.Dead -= ReturnToPool;
            }
        }
    }
}