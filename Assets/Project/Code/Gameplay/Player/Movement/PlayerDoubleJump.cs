using Project.Code.Configs;
using Project.Code.Gameplay.Input;
using UnityEngine;

namespace Project.Code.Gameplay.Player.Movement
{
    public class PlayerDoubleJump
    {
        private Rigidbody2D _rigidbody;
        private PlayerConfig _config;
        private PlayerInput _input;

        private float _jumpCurrentCooldown;

        public float CurrentJumpCooldown => _jumpCurrentCooldown;

        public PlayerDoubleJump(Rigidbody2D rigidbody, PlayerConfig config, PlayerInput input)
        {
            _input = input;
            _rigidbody = rigidbody;
            _config = config;
        }

        public void UpdateCooldown(float deltaTime)
        {
            _jumpCurrentCooldown += deltaTime;
        }

        public void SubscribeToEvents()
        {
            _input.JumpPressed += Jump;
        }

        public void UnsubscribeFromEvents()
        {
            _input.JumpPressed -= Jump;
        }

        private void Jump()
        {
            if (_jumpCurrentCooldown >= _config.DoubleJumpCooldown)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _config.DoubleJumpForce);
                _jumpCurrentCooldown = 0f;
            }
        }
    }
}