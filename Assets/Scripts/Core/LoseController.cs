using Players;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    //TODO Now is GOD class, need to rework with separated logic
    public class LoseController : MonoBehaviour
    {
        [SerializeField] private Canvas loseCanvas;
        [SerializeField] private Button restartButton;

        private Player _player;

        private void Awake() => loseCanvas.gameObject.SetActive(false);

        public void Initialize(Player player)
        {
            _player = player;

            _player.Dead += PlayerDead;
        }

        private void OnEnable() => restartButton.onClick.AddListener(RestartLevel);
        private void OnDisable() => restartButton.onClick.RemoveListener(RestartLevel);

        private void OnDestroy()
        {
            _player.Dead -= PlayerDead;
        }

        private void PlayerDead()
        {
            loseCanvas.gameObject.SetActive(true);
        }

        private void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}