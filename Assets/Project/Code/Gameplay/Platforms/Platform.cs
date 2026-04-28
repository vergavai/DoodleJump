using UnityEngine;

namespace Project.Code.Gameplay.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformType _platformType;
        
        public PlatformType PlatformType => _platformType;
    }
}
