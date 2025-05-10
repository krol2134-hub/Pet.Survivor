using System;
using Core;

namespace UI
{
    public class PauseUiMediator : IDisposable
    {
        private readonly PauseController _pauseController;
        private readonly PauseUiView _pauseUiView;
        
        public PauseUiMediator(PauseController pauseController, PauseUiView pauseUiView)
        {
            _pauseController = pauseController;
            _pauseUiView = pauseUiView;

            _pauseUiView.OnOpenClicked.AddListener(OpenClickedHandler);
            _pauseUiView.OnCloseClicked.AddListener(CloseClickedHandler);
        }

        public void Dispose()
        {
            _pauseUiView.OnOpenClicked.AddListener(OpenClickedHandler);
            _pauseUiView.OnCloseClicked.AddListener(CloseClickedHandler);
        }

        private void OpenClickedHandler()
        {
            _pauseUiView.SetShowState(true);
            _pauseController.EnablePause();
        }

        private void CloseClickedHandler()
        {
            _pauseUiView.SetShowState(false);
            _pauseController.DisablePause();
        }
    }
}