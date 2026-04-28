using Project.Code.Gameplay.ObjectGenerator;
using Project.Code.Gameplay.Player;
using Project.Code.Gameplay.Player.ScoreLogic;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.GameStages
{
    public class GameBehaviour : MonoBehaviour
    {
        [SerializeField] private PlatformGeneratorBehaviour _platformGenerator;
        
        private ScoreObserver _scoreObserver;
        private Game _game;

        [Inject]
        private void Construct(PlayerScore playerScore)
        {
            _game = new Game(playerScore, _platformGenerator);
        }

        private void OnEnable()
        {
            _game.SubscribeToEvents();
        }

        private void OnDisable()
        {
            _game.UnsubscribeFromEvents();
        }

        private void EnterGameStage(int stage)
        {
            _game.EnterGameStage(stage);
        }
    }
}