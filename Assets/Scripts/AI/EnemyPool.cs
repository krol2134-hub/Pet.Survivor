using System;
using System.Collections.Generic;
using AI.Enemies;
using Extensions;
using UnityEngine;
using UnityEngine.Pool;

namespace AI
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private int size = 10;
        
        private readonly Dictionary<EnemyType, ObjectPool<Enemy>> _pools = new();

        private EnemyFactory _factory;
        
        public void Initialize(EnemyFactory factory)
        {
            _factory = factory;
            
            foreach (EnemyType enemyType in Enum.GetValues(typeof(EnemyType))) 
                RegisterPool(enemyType);
        }
        
        private void RegisterPool(EnemyType type)
        {
            var newPool = new ObjectPool<Enemy>(CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy, false, defaultCapacity: size);
            newPool.Prewarm(size);
            _pools.Add(type, newPool);
            
            return;

            Enemy CreateFunc() => _factory.CreateEnemy(type, Vector3.zero, Quaternion.identity);

            void ActionOnGet(Enemy enemy)
            {
                enemy.gameObject.SetActive(true);
                enemy.ResetData();
            }

            void ActionOnRelease(Enemy enemy) => enemy.gameObject.SetActive(false);

            void ActionOnDestroy(Enemy enemy) => Destroy(enemy.gameObject);
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