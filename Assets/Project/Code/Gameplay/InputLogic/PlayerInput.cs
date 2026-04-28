using System;

namespace Project.Code.Gameplay.InputLogic
{
    public class PlayerInput 
    {
        private float _horizontalInput;
        
        public float HorizontalInput => _horizontalInput;

        public void UpdateInput(float rawHorizontalAxis)
        {
            _horizontalInput = rawHorizontalAxis;
        }
    }
}
