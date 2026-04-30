using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.GameBounds
{
    public class GameBoundsBehaviour : MonoBehaviour
    {
        private Transform _playerTransform;
        
        private Gameplay.GameBounds.GameBounds _gameBounds;

        [Inject]
        private void Construct(Gameplay.GameBounds.GameBounds gameBounds, PlayerMovementBehaviour player)
        {
            _gameBounds = gameBounds;
            _playerTransform = player.transform;
            
            _gameBounds.Initialize(_playerTransform);
        }

        private void Update()
        {
            if (!_playerTransform) return;
            
            _gameBounds.UpdateBounds();
        }
    }
}   