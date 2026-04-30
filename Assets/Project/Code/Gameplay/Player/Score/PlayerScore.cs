using System;

namespace Project.Code.Gameplay.Player.Score
{
    public class PlayerScore
    {
        private float _maxScore;
        private float _currentScore;
        
        public event Action<float> ScoreChanged;

        public void UpdateScore(float currentScore)
        {
            _currentScore = currentScore;
            
            if (_maxScore < _currentScore)
            {
                _maxScore = _currentScore;
                ScoreChanged?.Invoke(_maxScore);
            }
        }
    }
}