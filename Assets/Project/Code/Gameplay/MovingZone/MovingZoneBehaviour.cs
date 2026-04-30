using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.MovingZone
{
    public class MovingZoneBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _toMove;
        
        private Transform _player;
        private Gameplay.MovingZone.MovingZone _movingZone;

        [Inject]
        private void Construct(PlayerMovementBehaviour player)
        {
            _player = player.transform;
            
            _movingZone = new Gameplay.MovingZone.MovingZone(_player, _toMove, transform);
        }

        private void Update()
        {
            if(!_player) return;
            
            _movingZone.UpdateMoving();
        }
    }
}
    