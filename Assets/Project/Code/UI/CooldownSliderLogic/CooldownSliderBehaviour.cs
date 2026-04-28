using Project.Code.Configs;
using Project.Code.Constants;
using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Code.UI.CooldownSliderLogic
{
    public class CooldownSliderBehaviour : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
    
        private PlayerDoubleJumpBehaviour _playerDoubleJumpBehaviour;
        private PlayerConfig _playerConfig;
        private CooldownSlider _cooldownSlider;

        [Inject]
        private void Construct(PlayerDoubleJumpBehaviour playerDoubleJumpBehaviour)
        {
            _cooldownSlider = new CooldownSlider(_slider, playerDoubleJumpBehaviour);
        }

        private void Update()
        {
            _cooldownSlider.UpdateSlider();
        }
    }
}
