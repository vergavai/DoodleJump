using Zenject;

namespace Project.Code.Gameplay.Player.PlayerDeathLogic
{
    public class PlayerDeath
    {
        private readonly SignalBus _signalBus;

        public PlayerDeath(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Update(float playerY, float deathThresholdY)
        {
            if (playerY < deathThresholdY)
            {
                _signalBus.Fire<PlayerDiedSignal>();
            }
        }
    }
}