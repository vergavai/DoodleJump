using Project.Code.Configs;
using Project.Code.Gameplay.Input;
using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerDoubleJumpBehaviour : MonoBehaviour
    {
        private PlayerDoubleJump _playerDoubleJump;
        
        public PlayerDoubleJump PlayerDoubleJump => _playerDoubleJump;

        [Inject]
        private void Construct(PlayerConfig config, PlayerInput input)
        {
            _playerDoubleJump = new PlayerDoubleJump(GetComponent<Rigidbody2D>(), config, input);
        }

        private void OnEnable()
        {
            _playerDoubleJump.SubscribeToEvents();
        }

        private void OnDisable()
        {
            _playerDoubleJump.UnsubscribeFromEvents();
        }

        private void Update()
        {
            _playerDoubleJump.UpdateCooldown(Time.deltaTime);
        }
    }
}