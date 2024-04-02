using Enemies;
using UnityEngine;

namespace Core
{
    public class LevelBootstrapper : MonoBehaviour
    {
        [SerializeField] private Player.Player player;
        [SerializeField] private AIDirector aiDirector;
        [SerializeField] private EnemyFactory enemyFactory;

        private void Awake()
        {
            aiDirector.Initialize(player, enemyFactory);
        }
    }
}
