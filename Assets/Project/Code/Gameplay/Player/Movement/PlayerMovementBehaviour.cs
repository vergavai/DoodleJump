using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        [Inject]
        private void Construct(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
            
            _playerMovement.Initialize(GetComponent<Rigidbody2D>(), transform);
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