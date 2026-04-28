using Project.Code.Configs;
using Project.Code.Constants;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Code.Gameplay.ObjectGenerator
{
    public class PlatformGeneratorBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _platformsContainer;
        
        [SerializeField] private float _minYOffset;
        [SerializeField] private float _maxYOffset;
        [SerializeField] private float _yGenerationThreshold;
        [SerializeField] private float _spawnRangeX;

        private ObjectPool _pool;
        private Transform _cameraTransform;
        private GameStagesConfig _gameStagesConfig;
        private PlatformGeneratorConfig _generatorConfig;
        
        private float _lastGeneratedY;
        private float _cameraStartY;
        private float _disableOffset = 5f;

        private void Awake()
        {
            InitializeFields();

            AddPlatforms();
            
            for (int i = 0; i < 100 / 2; i++)
            {
                GenerateRandomPlatform();
            }
        }

        private void Update()   
        {
            if (_cameraTransform.position.y > _lastGeneratedY - _yGenerationThreshold)
            {
                GenerateRandomPlatform();
            }
            
            _pool.DisableObjectsBelowCamera(_cameraTransform.position.y, _disableOffset);
        }

        public void OnStageChanged(int stage)
        {
            _pool.AddNewType(_generatorConfig.MovingPlatformPrefab, _gameStagesConfig.ObjectsToAddPerStage[stage]);
            _maxYOffset = _gameStagesConfig.MaxYOffsetPerStage[stage];
        }

        private void GenerateRandomPlatform()
        {
            if (!_pool.TryGetRandomObject(out GameObject platform))
                return;

            float newY = _lastGeneratedY + Random.Range(_minYOffset, _maxYOffset);
            float randomX = Random.Range(-_spawnRangeX, _spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, newY, 0f);

            platform.transform.position = spawnPosition;
            platform.SetActive(true);
            _lastGeneratedY = newY;
        }

        private void InitializeFields()
        {
            _gameStagesConfig = Resources.Load<GameStagesConfig>(ConfigPaths.GameStagesConfig);
            _generatorConfig = Resources.Load<PlatformGeneratorConfig>(ConfigPaths.PlatformGeneratorConfig);
            
            _cameraTransform = Camera.main.transform;
            _cameraStartY = _cameraTransform.position.y;
            _lastGeneratedY = _cameraStartY;

            _pool = new ObjectPool(_platformsContainer, Camera.main);
        }

        private void AddPlatforms()
        {
            _pool.AddNewType(_generatorConfig.PlatformPrefab, _generatorConfig.PlatformsCount);
            _pool.AddNewType(_generatorConfig.SpringPrefab, _generatorConfig.SpringsCount);
            _pool.AddNewType(_generatorConfig.BreakablePlatformPrefab, _generatorConfig.BreakablePlatformsCount);
        }
    }
}