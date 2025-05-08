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
        [SerializeField] private LoseView loseView;

        private PauseController _pauseController;
        private LoseController _loseController;
        
        //TODO Use DI/VContanier
        private void Awake()
        {
            enemyFactory.Initialize(player);
            enemyPool.Initialize(enemyFactory);
            aiDirector.Initialize(enemyPool);

            _pauseController = new PauseController(player);
            _loseController = new LoseController(player, loseView);
        }

        private void OnDestroy()
        {
            _pauseController.Dispose();
            _loseController.Dispose();
        }
    }
}