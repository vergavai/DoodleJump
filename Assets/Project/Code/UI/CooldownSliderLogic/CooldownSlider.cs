using Project.Code.Configs;
using Project.Code.Constants;
using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Code.UI.CooldownSliderLogic
{
    public class CooldownSlider
    {
        private Slider _slider;
    
        private PlayerDoubleJumpBehaviour _playerDoubleJumpBehaviour;
        private PlayerConfig _playerConfig;

        public CooldownSlider(Slider slider, PlayerDoubleJumpBehaviour playerDoubleJumpBehaviour)
        {
            _slider = slider;
            _playerDoubleJumpBehaviour = playerDoubleJumpBehaviour;
            _playerConfig = Resources.Load<PlayerConfig>(ConfigPaths.PlayerConfig);
        }

        public void UpdateSlider()
        {
            _slider.value = _playerDoubleJumpBehaviour.PlayerDoubleJump.CurrentJumpCooldown /
                            _playerConfig.DoubleJumpCooldown;
        }
    }
}