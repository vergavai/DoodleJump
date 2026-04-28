using System;

namespace Project.Code.Gameplay.Platforms
{
    public class PlatformDetector
    {
        public event Action<float> PlatformDetected;

        public void InvokePlatformDetected(float number)
        {
            PlatformDetected?.Invoke(number);
        }
    }
}