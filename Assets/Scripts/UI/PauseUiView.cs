using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseUiView : MonoBehaviour
    {
        [SerializeField] private Button openButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private Transform closeContainer;
        [SerializeField] private Transform openContainer;

        public Button.ButtonClickedEvent OnOpenClicked => openButton.onClick;
        public Button.ButtonClickedEvent OnCloseClicked => closeButton.onClick;

        private void Awake()
        {
            SetShowState(false);
        }

        public void SetShowState(bool open)
        {
            closeContainer.gameObject.SetActive(!open);
            openContainer.gameObject.SetActive(open);
        }
    }
}