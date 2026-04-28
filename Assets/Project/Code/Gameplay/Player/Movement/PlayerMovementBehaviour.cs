using Project.Code.Configs;
using Project.Code.Constants;
using Project.Code.Gameplay.InputLogic;
using Project.Code.Gameplay.Platforms;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputBehaviour))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        private PlayerConfig _config;
        private Rigidbody2D _rigidbody;
        private PlayerInput _input;
        private PlatformDetector _platformDetector;
        private PlayerMovement _playerMovement;

        [Inject]
        private void Construct(PlayerInput input, PlatformDetector detector)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _config = Resources.Load<PlayerConfig>(ConfigPaths.PlayerConfig);
            _input = input;
            _platformDetector = detector;
            
            _playerMovement = new PlayerMovement(_config, _rigidbody, transform, _input, _platformDetector);
        }

        private void OnEnable()
        {
            _playerMovement.SubscribeToEvents();
        }

        private void Start()
        {
            _playerMovement.SetStartVelocity();
        }

        private void FixedUpdate()
        {
            _playerMovement.UpdateMovement();
        }

        private void OnDisable()
        {
            _playerMovement.UnsubscribeFromEvents();
        }
    }
}