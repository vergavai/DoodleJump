using Project.Code.Configs;
using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Code.UI.CooldownSlider
{
    public class CooldownSlider
    {
        private Slider _slider;
    
        private PlayerDoubleJumpBehaviour _playerDoubleJumpBehaviour;
        private PlayerConfig _playerConfig;

        public CooldownSlider(Slider slider, PlayerDoubleJumpBehaviour playerDoubleJumpBehaviour, PlayerConfig playerConfig)
        {
            _slider = slider;
            _playerDoubleJumpBehaviour = playerDoubleJumpBehaviour;
            _playerConfig = playerConfig;
        }

        public void UpdateSlider()
        {
            _slider.value = Mathf.Clamp01(_playerDoubleJumpBehaviour.PlayerDoubleJump.CurrentJumpCooldown /
                                          _playerConfig.DoubleJumpCooldown);
        }
    }
}