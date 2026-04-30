using Zenject;

namespace Project.Code.Gameplay.Player.Death
{
    public class PlayerDeath
    {
        private readonly SignalBus _signalBus;
        private bool _isDead;

        public PlayerDeath(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void CheckDeath(float playerY, float deathThresholdY)
        {
            _isDead = playerY < deathThresholdY;
            
            if (_isDead)
            {
                _signalBus.Fire<PlayerDiedSignal>();
            }
        }
    }
}