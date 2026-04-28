using Project.Code.Gameplay.Player;
using Project.Code.Gameplay.Player.ScoreLogic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Project.Code.UI.Score
{
    public class ScoreTextBehaviour : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _text;
        
        private PlayerScore _playerScore;
        
        private ScoreText _scoreText;

        [Inject]
        private void Construct(PlayerScore playerScore)
        {
            _playerScore = playerScore;
         
            _scoreText = new ScoreText(_text, _playerScore);
        }

        private void Update()
        {
            _scoreText.UpdateScoreText();
        }
    }
}
