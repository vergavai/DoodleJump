using Project.Code.Configs;
using Project.Code.Gameplay.Input;
using Project.Code.Gameplay.Platforms;
using UnityEngine;

namespace Project.Code.Gameplay.Player.Movement
{
    public class PlayerMovement
    {
        private PlayerConfig _config;
        private Rigidbody2D _rigidbody;
        private Transform _playerTransform;
        private PlayerInput _input;
        private PlatformDetector _platformDetector;

        private const int FacingRight = 1;
        private const int FacingLeft = -1;

        public PlayerMovement(PlayerConfig config, PlayerInput input,
            PlatformDetector platformDetector)
        {
            _config = config;
            _input = input;
            _platformDetector = platformDetector;
        }

        public void Initialize(Rigidbody2D rigidbody, Transform transform)
        {
            _rigidbody = rigidbody;
            _playerTransform = transform;
        }

        public void SetStartVelocity()
        {
            _rigidbody.velocity = Vector2.up * _config.PlatformJumpForce;
        }

        public void SubscribeToEvents()
        {
            _platformDetector.JumpRequested += JumpRequested;
        }

        public void UnsubscribeFromEvents()
        {
            _platformDetector.JumpRequested -= JumpRequested;
        }

        public void UpdateMovement()
        {
            _rigidbody.velocity = new Vector2(_config.HorizontalSpeed * _input.HorizontalInput,
                _rigidbody.velocity.y);

            FlipDirection();
        }

        private void JumpRequested(float yForce)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, yForce);
        }

        private void FlipDirection()
        {
            _playerTransform.localScale = _input.HorizontalInput switch
            {
                FacingRight => new Vector3(Mathf.Abs(_playerTransform.localScale.x), _playerTransform.localScale.y,
                    _playerTransform.localScale.z),
                FacingLeft => new Vector3(-Mathf.Abs(_playerTransform.localScale.x), _playerTransform.localScale.y,
                    _playerTransform.localScale.z),
                _ => _playerTransform.localScale
            };
        }
    }
}