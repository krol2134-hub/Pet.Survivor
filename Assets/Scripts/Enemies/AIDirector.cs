using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{   
    public class AIDirector : MonoBehaviour
    {
        [SerializeField] private int maxEnemyCount = 10;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Player.Player player;

        [SerializeField] private EnemyFactory factory;

        private void Start() => SpawnEnemies(maxEnemyCount);

        private void SpawnEnemies(int spawnCount)
        {
            for (var i = 0; i < spawnCount - 1; i++)
            {
                var enemyType = GetRandomEnemyType();
                var position = GetRandomSpawnPosition();

                var enemy = factory.CreateEnemy(enemyType, position);
                enemy.Initialize(player);
            }
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
