using Project.Code.Gameplay.Player;
using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.GameBoundsLogic
{
    public class GameBoundsBehaviour : MonoBehaviour
    {
        Transform _playerTransform;
        
        private GameBounds _gameBounds;

        [Inject]
        private void Construct(PlayerMovementBehaviour player)
        {
            _playerTransform = player.transform;
            
            _gameBounds = new GameBounds(Camera.main, player.transform);
        }

        private void Update()
        {
            if (!_playerTransform) return;
            
            _gameBounds.UpdateBounds();
        }
    }
}