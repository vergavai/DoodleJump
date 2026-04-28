using Project.Code.Configs;
using Project.Code.Constants;
using UnityEngine;

namespace Project.Code.Gameplay.Player.Movement
{
    public class PlayerDoubleJump
    {
        private Rigidbody2D _rigidbody;
        private PlayerConfig _config;
        
        private float _jumpCurrentCooldown;
        
        public float CurrentJumpCooldown => _jumpCurrentCooldown;

        public PlayerDoubleJump(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
            _config = Resources.Load<PlayerConfig>(ConfigPaths.PlayerConfig);
        }
        
        public void Update()
        {
            _jumpCurrentCooldown += Time.deltaTime;

            if (_jumpCurrentCooldown >= _config.DoubleJumpCooldown)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _config.DoubleJumpForce);
                    _jumpCurrentCooldown = 0f;
                }
            }
        }
    }
}