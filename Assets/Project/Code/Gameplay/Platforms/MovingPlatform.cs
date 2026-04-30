using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.Code.Gameplay.Platforms
{
    public class MovingPlatform : Platform
    {
        [SerializeField] private float _speed;
        
        private Camera _camera;
        private Rigidbody2D _rigidbody;
        private Vector3 _leftEdge;
        private Vector3 _rightEdge;

        [Inject]
        private void Construct(Camera mainCamera)
        {
            _camera = mainCamera;
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _leftEdge = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f, -_camera.transform.position.z));
            _rightEdge = new Vector3(-_leftEdge.x, _leftEdge.y, _leftEdge.z);
        }

        private void OnEnable()
        {
            _rigidbody.velocity = Random.Range(0, 2) == 0 ? Vector2.right * _speed : Vector2.left * _speed;
        }

        private void FixedUpdate()
        {
            MoveAround();
        }

        private void MoveAround()
        {
            if (transform.position.x < _leftEdge.x)
            {
                _rigidbody.velocity = Vector2.right;
            }
            else if (transform.position.x > _rightEdge.x)
            {
                _rigidbody.velocity = Vector2.left;
            }
        }
    }
}
