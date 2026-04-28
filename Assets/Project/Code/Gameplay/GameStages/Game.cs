using Project.Code.Gameplay.ObjectGenerator;
using Project.Code.Gameplay.Player;
using Project.Code.Gameplay.Player.ScoreLogic;
using Zenject;

namespace Project.Code.Gameplay.GameStages
{
    public class Game
    {
        private PlatformGeneratorBehaviour _platformGenerator;
        
        private ScoreObserver _scoreObserver;

        public Game(PlayerScore playerScore, PlatformGeneratorBehaviour platformGenerator)
        {
            _scoreObserver = new ScoreObserver(playerScore);
            _platformGenerator = platformGenerator;
        }

        public void SubscribeToEvents()
        {
            _scoreObserver.SubscribeToEvents();
            _scoreObserver.OnStageReached += EnterGameStage;
        }

        public void UnsubscribeFromEvents()
        {
            _scoreObserver.UnsubscribeFromEvents();
            _scoreObserver.OnStageReached -= EnterGameStage;
        }

        public void EnterGameStage(int stage)
        {
            _platformGenerator.OnStageChanged(stage);
        }
    }
}