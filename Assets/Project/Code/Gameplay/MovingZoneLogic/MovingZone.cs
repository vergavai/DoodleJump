using UnityEngine;

namespace Project.Code.Gameplay.MovingZoneLogic
{
    public class MovingZone
    {
        private Transform _player;
        private Transform _toMove;
        private Transform _selfPosition;
        
        public MovingZone(Transform player, Transform toMove, Transform selfPosition)
        {
            _player = player;
            _toMove = toMove;
            _selfPosition = selfPosition;
        }
        
        public void UpdateMoving()
        {
            if (_player.position.y > _selfPosition.position.y)
            {
                _toMove.position = new Vector3(_toMove.position.x, _toMove.position.y + _player.position.y - _selfPosition.position.y, _toMove.position.z);
            }
        }
    }
}
