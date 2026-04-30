using Project.Code.UI.Menu.StartMenu;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Code.UI.Menu.GameOver
{
    public class GameOverMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _restartButton;

        private GameOverMenu _gameOverMenu;

        [Inject]
        private void Construct(GameSceneLoader gameSceneLoader, SignalBus signalBus)
        {
            _gameOverMenu = new GameOverMenu(_canvasGroup, gameSceneLoader, _restartButton, signalBus);
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