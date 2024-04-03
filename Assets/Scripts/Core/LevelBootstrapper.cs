using AI;
using UnityEngine;

namespace Core
{
    public class LevelBootstrapper : MonoBehaviour
    {
        [SerializeField] private Player.Player player;
        [SerializeField] private AIDirector aiDirector;
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private LoseController loseController;

        private void Awake()
        {
            enemyFactory.Initialize(player);
            enemyPool.Initialize(enemyFactory);
            aiDirector.Initialize(enemyPool);
            loseController.Initialize(player);
        }
    }
}
