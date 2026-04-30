using Project.Code.Gameplay.ObjectGenerator;

namespace Project.Code.Gameplay.GameStages
{
    public class StageProgression
    {
        private PlatformGenerator _platformGenerator;
        
        private ScoreObserver _scoreObserver;

        public StageProgression(ScoreObserver scoreObserver, PlatformGenerator platformGenerator)
        {
            _scoreObserver = scoreObserver;
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