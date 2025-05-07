using System;
using Players;
using UnityEngine;

namespace Core
{
    public class PauseController : IDisposable
    {
        private readonly Player _player;

        public PauseController(Player player)
        {
            _player = player;

            _player.Dead += PlayerDeadHandler;
        }

        public void Dispose()
        {
            _player.Dead -= PlayerDeadHandler;
            Time.timeScale = 1f;
        }

        private void PlayerDeadHandler()
        {
            Time.timeScale = 0f;
        }
    }
}