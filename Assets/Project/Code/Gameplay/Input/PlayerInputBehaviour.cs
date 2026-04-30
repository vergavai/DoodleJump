using UnityEngine;
using Zenject;

namespace Project.Code.Gameplay.Input
{
    public class PlayerInputBehaviour : MonoBehaviour
    {
        private PlayerInput _input;
        private const string HorizontalAxis = "Horizontal";

        [Inject]
        private void Construct(PlayerInput input)
        {
            _input = input;
        }

        private void Update()
        {
            float input = UnityEngine.Input.GetAxisRaw(HorizontalAxis);
            _input.UpdateInput(input);
        }
    }
}