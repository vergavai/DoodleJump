using Project.Code.Gameplay.Player.Movement;
using UnityEngine;

namespace Project.Code.Gameplay.Player.Tracker
{
    public class PlayerTracker
    {
        private PlayerMovementBehaviour _player;
        private Transform _transform;
        private float _yOffset;
        
        public PlayerTracker(PlayerMovementBehaviour player, Transform transform, float yOffset)
        {
            _player = player;
            _transform = transform;
            _yOffset = yOffset;
        }

        public void UpdatePosition()
        {
            _transform.position = new Vector3(_transform.position.x, _player.transform.position.y - _yOffset, _transform.position.z);
        }
    }

}
