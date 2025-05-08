using UnityEngine;
using UnityEngine.UI;

namespace Core.Lose
{
    public class LoseView : MonoBehaviour
    {
        [SerializeField] private Canvas loseCanvas;
        [SerializeField] private Button restartButton;

        public Button.ButtonClickedEvent RestartClicked => restartButton.onClick;
        
        private void Awake()
        {
            loseCanvas.gameObject.SetActive(false);
        }

        public void Open()
        {
            loseCanvas.gameObject.SetActive(true);
        }
    }
}