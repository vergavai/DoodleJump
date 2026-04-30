using Project.Code.Gameplay.Player.Movement;
using UnityEngine;

namespace Project.Code.Gameplay.Player.Tracker
{
    public class PlayerTracker
    {
        private readonly PlayerMovementBehaviour _player;
        private readonly Transform _transform;
        private readonly float _yOffset;
        
        public PlayerTracker(PlayerMovementBehaviour player, Transform transform, float yOffset)
        {
            _player = player;
            _transform = transform;
            _yOffset = yOffset;
        }

        public void UpdatePosition()
        {
            if (!_player) return;
            
            _transform.position = new Vector3(_transform.position.x, _player.transform.position.y - _yOffset, _transform.position.z);
        }
    }

}
