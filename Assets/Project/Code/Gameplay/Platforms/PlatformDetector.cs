using System;

namespace Project.Code.Gameplay.Platforms
{
    public class PlatformDetector
    {
        public event Action<float> JumpRequested;

        public void InvokeJumpRequest(float number)
        {
            JumpRequested?.Invoke(number);
        }
    }
}