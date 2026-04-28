using System;
using Project.Code.Gameplay.Player.PlayerDeathLogic;
using Project.Code.UI.Menu.StartMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Code.UI.Menu.GameOverMenuLogic
{
    public class GameOverMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _restartButton;
        
        private PlayerDeath _player;
        private GameSceneLoader _gameSceneLoader;
        
        private GameOverMenu _gameOverMenu;

        [Inject]
        private void Construct(PlayerDeath playerDeath, GameSceneLoader gameSceneLoader, SignalBus signalBus)
        {
            _player = playerDeath;
            _gameSceneLoader = gameSceneLoader;
            
            _gameOverMenu = new GameOverMenu(_canvasGroup, playerDeath, gameSceneLoader, _restartButton, signalBus);
        }

        private void OnEnable()
        {
            _gameOverMenu.SubscribeToEvents();
        }

        private void OnDisable()
        {
            _gameOverMenu.UnsubscribeFromEvents();
        }
    }
}