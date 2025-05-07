using System;
using AI;
using Players;
using UnityEngine;

namespace Core
{
    public class LevelBootstrapper : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private AIDirector aiDirector;
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private LoseController loseController;

        private PauseController _pauseController;
        
        
        private void Awake()
        {
            enemyFactory.Initialize(player);
            enemyPool.Initialize(enemyFactory);
            aiDirector.Initialize(enemyPool);
            loseController.Initialize(player);

            _pauseController = new PauseController(player);
        }

        private void OnDestroy()
        {
            _pauseController.Dispose();
        }
    }
}