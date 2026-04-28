using UnityEngine;

namespace Project.Code.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 51)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private float _platformJumpForce;
        [SerializeField] private float _springForce;
        [SerializeField] private float _doubleJumpForce;
        [SerializeField] private float _doubleJumpCooldown;
        
        public float HorizontalSpeed => _horizontalSpeed;
        public float PlatformJumpForce => _platformJumpForce;
        public float SpringForce => _springForce;
        public float DoubleJumpForce => _doubleJumpForce;
        public float DoubleJumpCooldown => _doubleJumpCooldown;
    }
}
