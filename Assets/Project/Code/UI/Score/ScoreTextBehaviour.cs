using Project.Code.Gameplay.Player.Score;
using TMPro;
using UnityEngine;
using Zenject;

namespace Project.Code.UI.Score
{
    public class ScoreTextBehaviour : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        private PlayerScore _playerScore;
        
        private ScoreText _scoreText;

        [Inject]
        private void Construct(PlayerScore playerScore)
        {
            _playerScore = playerScore;
         
            _scoreText = new ScoreText(_text, _playerScore);
        }

        private void OnEnable()
        {
            _scoreText.SubscribeToEvents();
        }

        private void OnDisable()
        {
            _scoreText.UnsubscribeFromEvents();
        }
    }
}
