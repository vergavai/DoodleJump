using UnityEngine;

namespace Project.Code.Gameplay.GameBoundsLogic
{
    public class GameBounds
    {
        private Camera _camera;
        private Transform _transform;

        private float _leftBound;
        private float _rightBound;

        private Vector3 _leftEdge;
        private Vector3 _rightEdge;

        public GameBounds(Camera camera, Transform transform)
        {
            _camera = camera;
            _transform = transform;
            
            _leftEdge = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f, -_camera.transform.position.z));
            _rightEdge = _camera.ViewportToWorldPoint(new Vector3(1, 0.5f, -_camera.transform.position.z));
            
            _leftBound = _leftEdge.x;
            _rightBound = _rightEdge.x;
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