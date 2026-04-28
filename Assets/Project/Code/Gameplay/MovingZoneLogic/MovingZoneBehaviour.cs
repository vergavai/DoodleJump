using Project.Code.Gameplay.Player;
using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.MovingZoneLogic
{
    public class MovingZoneBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _toMove;
        
        private Transform _player;
        private MovingZone _movingZone;

        [Inject]
        public void Construct(PlayerMovementBehaviour player)
        {
            _player = player.transform;
            
            _movingZone = new MovingZone(_player, _toMove, transform);
        }

        private void Update()
        {
            if(!_player) return;
            
            _movingZone.UpdateMoving();
        }
    }
}
    