using Project.Code.Gameplay.Player.Score;
using TMPro;
using UnityEngine;

namespace Project.Code.UI.Score
{
    public class ScoreText
    {
        private TextMeshProUGUI _text;
        private PlayerScore _playerScore;
        
        public ScoreText(TextMeshProUGUI text, PlayerScore playerScore)
        {
            _text = text;
            _playerScore = playerScore;
        }

        public void SubscribeToEvents()
        {
            _playerScore.ScoreChanged += UpdateScoreText;
        }

        public void UnsubscribeFromEvents()
        {
            _playerScore.ScoreChanged -= UpdateScoreText;
        }

        public void UpdateScoreText(float score)
        {
            string scoreText = $"Score: {Mathf.Round(score)}";

            _text.text = scoreText;
        }
    }
}