using Project.Code.Gameplay.Player.PlayerDeathLogic;
using Project.Code.UI.Menu.StartMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Code.UI.Menu.GameOverMenuLogic
{
    public class GameOverMenu
    {
        private PlayerDeath _player;
        private CanvasGroup _canvasGroup;
        private Button _restartButton;
        private GameSceneLoader _gameSceneLoader;
        private SignalBus _signalBus;

        public GameOverMenu(CanvasGroup canvasGroup, PlayerDeath player, GameSceneLoader gameSceneLoader, Button restartButton, SignalBus signalBus)
        {
            _player = player;
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