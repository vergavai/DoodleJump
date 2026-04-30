using Project.Code.Configs;
using Project.Code.Gameplay.Player.Movement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Code.UI.CooldownSlider
{
    public class CooldownSliderBehaviour : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
    
        private CooldownSlider _cooldownSlider;

        [Inject]
        private void Construct(PlayerDoubleJumpBehaviour playerDoubleJumpBehaviour, PlayerConfig playerConfig)
        {
            _cooldownSlider = new CooldownSlider(_slider, playerDoubleJumpBehaviour, playerConfig);
            _cooldownSlider = new CooldownSlider(_slider, playerDoubleJumpBehaviour, playerConfig);
        }

        private void Update()
        {
            _cooldownSlider.UpdateSlider();
        }
    }
}
