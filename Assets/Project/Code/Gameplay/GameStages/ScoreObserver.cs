using System;
using Project.Code.Configs;
using Project.Code.Constants;
using Project.Code.Gameplay.Player;
using Project.Code.Gameplay.Player.Score;
using UnityEngine;

namespace Project.Code.Gameplay.GameStages
{
    public class ScoreObserver
    {
        private PlayerScore _playerScore;
        private GameStagesConfig _config;
        private bool[] _stageAchieved;
        private int[] _thresholds;

        public event Action<int> OnStageReached;
        
        public ScoreObserver(PlayerScore playerScore,  GameStagesConfig config)
        {
            _playerScore = playerScore;
            _config = config;
            _stageAchieved = new bool[]{false, false};
            _thresholds = _config.ScoreThresholds;
        }

        public void SubscribeToEvents()
        {
            _playerScore.ScoreChanged += OnScoreChanged;
        }

        public void UnsubscribeFromEvents()
        {
            _playerScore.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(float score)
        {
            for (int i = 0; i < _thresholds.Length; i++)
            {
                if (!_stageAchieved[i] && score > _thresholds[i])
                {
                    _stageAchieved[i] = true;
                    OnStageReached?.Invoke(i);
                }
            }
        }
    }
}