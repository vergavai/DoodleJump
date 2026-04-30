using UnityEngine;

namespace Project.Code.Gameplay.GameBounds
{
    public class GameBounds
    {
        private Transform _transform;

        private float _leftBound;
        private float _rightBound;

        public GameBounds(Camera camera)
        {
            _leftBound = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, -camera.transform.position.z)).x;
            _rightBound = -_leftBound;
        }

        public void Initialize(Transform transform)
        {
            _transform = transform;
        }

        public void UpdateBounds()
        {
            
            Vector3 pos = _transform.position;

            if (pos.x < _leftBound)
            {
                pos.x = _rightBound;
                _transform.position = pos;
            }
            else if (pos.x > _rightBound)
            {
                pos.x = _leftBound;
                _transform.position = pos;
            }
        }
    }
}