using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Player.Score
{
    public class PlayerScoreBehaviour : MonoBehaviour
    {
        private const float ScoreMultiplier = 12.34f;
        
        private PlayerScore _playerScore;

        [Inject]
        private void Construct(PlayerScore playerScore)
        {
            _playerScore = playerScore;
        }

        private void Update()
        {
            float currentScore = transform.position.y * ScoreMultiplier;
            
            _playerScore.UpdateScore(currentScore);
        }
    }
}
