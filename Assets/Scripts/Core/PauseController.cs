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

            _player.Dead += EnablePause;
        }

        public void Dispose()
        {
            DisablePause();
            
            _player.Dead -= EnablePause;
        }

        public void EnablePause()
        {
            Time.timeScale = 0f;
        }
        
        public void DisablePause()
        {
            Time.timeScale = 1f;
        }
    }
}