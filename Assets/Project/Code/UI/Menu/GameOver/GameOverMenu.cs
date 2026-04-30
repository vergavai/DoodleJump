using Project.Code.Gameplay.Player.Death;
using Project.Code.UI.Menu.StartMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Code.UI.Menu.GameOver
{
    public class GameOverMenu
    {
        private CanvasGroup _canvasGroup;
        private Button _restartButton;
        private GameSceneLoader _gameSceneLoader;
        private SignalBus _signalBus;

        public GameOverMenu(CanvasGroup canvasGroup, GameSceneLoader gameSceneLoader, Button restartButton, SignalBus signalBus)
        {
            _canvasGroup = canvasGroup;
            _restartButton = restartButton;
            _gameSceneLoader = gameSceneLoader;
            _signalBus = signalBus;
        }

        public void SubscribeToEvents()
        {
            _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDeath);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        public void UnsubscribeFromEvents()
        {
            _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDeath);
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        }
        
        private void OnPlayerDeath()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
        }

        private void OnRestartButtonClick()
        {
            _gameSceneLoader.LoadGameScene();
        }
    }
}