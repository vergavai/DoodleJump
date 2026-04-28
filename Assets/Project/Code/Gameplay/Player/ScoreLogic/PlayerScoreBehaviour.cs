using System;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Player.ScoreLogic
{
    public class PlayerScoreBehaviour : MonoBehaviour
    {
        private readonly float _scoreMultiplier = 12.34f;
        
        private PlayerScore _playerScore;

        [Inject]
        private void Construct(PlayerScore playerScore)
        {
            _playerScore = playerScore;
        }

        private void Update()
        {
            float currentScore = transform.position.y * _scoreMultiplier;
            
            _playerScore.UpdateScore(currentScore);
        }
    }
}
