using System;
using UnityEngine;

namespace Project.Code.Gameplay.Player.Movement
{
    public class PlayerDoubleJumpBehaviour : MonoBehaviour
    {
        private PlayerDoubleJump _playerDoubleJump;
        
        public PlayerDoubleJump PlayerDoubleJump => _playerDoubleJump;

        private void Awake()
        {
            _playerDoubleJump = new PlayerDoubleJump(GetComponent<Rigidbody2D>());
        }

        private void Update()
        {
            _playerDoubleJump.Update();
        }
    }
}