using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Player.PlayerDeathLogic
{
    public class PlayerDeathBehaviour : MonoBehaviour
    {
        private PlayerDeath _playerDeath;
        private Camera _camera;
        private SignalBus _signalBus;
    
        private float _offset = 0.3f;
        private float _distance;
    
        [Inject]
        private void Construct(PlayerDeath playerDeath, SignalBus signalBus)
        {
            _playerDeath = playerDeath;
            _signalBus = signalBus;
            _camera = Camera.main;
            _distance = _camera.nearClipPlane;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
        }

        private void Update()
        {
            float bottomY = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, _distance)).y;
            _playerDeath.Update(transform.position.y, bottomY + _offset);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDied);
        }

        private void OnPlayerDied()
        {
            Destroy(gameObject);
        }
    }
}