using System;
using Players;

namespace Core
{
    //TODO Now is GOD class, need to rework with separated logic
    public class LoseController : IDisposable
    {
        private readonly Player _player;
        private readonly LoseView _loseView;

        public LoseController(Player player, LoseView loseView)
        {
            _player = player;
            _loseView = loseView;

            _player.Dead += PlayerDead;
            _loseView.RestartClicked.AddListener(RestartLevel);
        }

        public void Dispose()
        {
            _player.Dead -= PlayerDead;
            _loseView.RestartClicked.RemoveListener(RestartLevel);
        }

        private void PlayerDead()
        {
            _loseView.Open();
        }

        private void RestartLevel()
        {
            SceneLoader.RestartLevel();
        }
    }
}