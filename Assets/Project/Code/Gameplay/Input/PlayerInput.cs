using System;
using UnityEngine;

namespace Project.Code.Gameplay.Input
{
    public class PlayerInput 
    {
        private float _horizontalInput;
        
        public float HorizontalInput => _horizontalInput;

        public event Action JumpPressed;

        public void UpdateInput(float rawHorizontalAxis)
        {
            _horizontalInput = rawHorizontalAxis;

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                JumpPressed?.Invoke();
            }

        }
    }
}
