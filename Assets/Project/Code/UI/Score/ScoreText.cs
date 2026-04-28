using Project.Code.Gameplay.Player;
using Project.Code.Gameplay.Player.ScoreLogic;
using TMPro;

namespace Project.Code.UI.Score
{
    public class ScoreText
    {
        TextMeshProUGUI _text;
        
        private PlayerScore _playerScore;
        
        public ScoreText(TextMeshProUGUI text, PlayerScore playerScore)
        {
            _text = text;
            _playerScore = playerScore;
        }

        public void UpdateScoreText()
        {
            _text.text = $"Score: {_playerScore.MaxScore}";
        }
    }
}