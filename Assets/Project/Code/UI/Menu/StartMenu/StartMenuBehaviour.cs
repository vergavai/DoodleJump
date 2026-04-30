using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Code.UI.Menu.StartMenu
{
    public class StartMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        
        private GameSceneLoader _gameSceneLoader;
        
        [Inject]
        private void Construct(GameSceneLoader gameSceneLoader)
        {
            _gameSceneLoader = gameSceneLoader;
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClick);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
        }

        private void OnStartButtonClick()
        {
            _gameSceneLoader.LoadGameScene();
        }
    }
}
