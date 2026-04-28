using Project.Code.Configs;
using Project.Code.Constants;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Platforms
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlatformDetectorBehaviour : MonoBehaviour
    {
        private PlayerConfig _config;
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;
        private PlatformDetector _detector;

        private float _verticalOffset = 0.5f;

        [Inject]
        public void Construct(PlatformDetector detector)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _config = Resources.Load<PlayerConfig>(ConfigPaths.PlayerConfig);
            _detector = detector;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Platform platform) && _rigidbody.velocity.y < 0)
            {
                float platformTop = other.bounds.max.y;
                float playerBottom = _collider.bounds.min.y;

                if (playerBottom >= platformTop - _verticalOffset)
                {
                    switch (platform.PlatformType)
                    {
                        case PlatformType.BrokenPlatform:
                            other.gameObject.SetActive(false);
                            break;
                        case PlatformType.Platform:
                            _detector.InvokePlatformDetected(_config.PlatformJumpForce);
                            break;
                        case PlatformType.SpringPlatform:
                            _detector.InvokePlatformDetected(_config.SpringForce);
                            break;
                    }
                }
            }
        }
    }
}