using UnityEngine;

namespace Project.Code.Configs
{
    [CreateAssetMenu(fileName = "PlatformGeneratorConfig", menuName = "Configs/PlatformGeneratorConfig", order = 51)]
    public class PlatformGeneratorConfig : ScriptableObject
    {
        [SerializeField] private GameObject _platformPrefab;
        [SerializeField] private GameObject _springPrefab;
        [SerializeField] private GameObject _breakablePlatformPrefab;
        [SerializeField] private GameObject _movingPlatformPrefab;

        [SerializeField] private int _platformsCount;
        [SerializeField] private int _springsCount;
        [SerializeField] private int _breakablePlatformsCount;

        public GameObject PlatformPrefab => _platformPrefab;
        public GameObject SpringPrefab => _springPrefab;
        public GameObject BreakablePlatformPrefab => _breakablePlatformPrefab;
        public GameObject MovingPlatformPrefab => _movingPlatformPrefab;

        public int PlatformsCount => _platformsCount;
        public int SpringsCount => _springsCount;
        public int BreakablePlatformsCount => _breakablePlatformsCount;
    }
}