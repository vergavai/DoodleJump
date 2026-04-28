using System;
using UnityEngine;

namespace Project.Code.Gameplay.Player.ScoreLogic
{
    public class PlayerScore
    {
        private float _maxScore;
        private float _currentScore;
        
        public event Action<float> ScoreChanged;
        
        public float CurrentScore => _currentScore;
        public float MaxScore => _maxScore;

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