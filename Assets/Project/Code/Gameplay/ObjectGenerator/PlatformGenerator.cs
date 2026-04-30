using System.Collections.Generic;
using Project.Code.Configs;
using Project.Code.Constants;
using Project.Code.Gameplay.Platforms;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.Code.Gameplay.ObjectGenerator
{
    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _platformContainer;

        [SerializeField] private float _minYOffset;
        [SerializeField] private float _maxYOffset;
        [SerializeField] private float _yGenerationThreshold;
        [SerializeField] private float _spawnRangeX;
        [SerializeField] private float _disableOffset;
        [SerializeField] private int platformsOnStart;

        private ObjectPool _pool;
        private Transform _cameraTransform;
        private GameStagesConfig _gameStagesConfig;
        private PlatformCreator _platformCreator;
        private List<List<GameObject>> _platformsToAdd;

        private float _lastGeneratedY;
        private float _cameraStartY;

        [Inject]
        private void Construct(GameStagesConfig gameStagesConfig,
            Camera mainCamera, ObjectPool objectPool, PlatformCreator creator)
        {
            _gameStagesConfig = gameStagesConfig;

            _cameraTransform = mainCamera.transform;
            _cameraStartY = _cameraTransform.position.y;
            _lastGeneratedY = _cameraStartY;

            _platformCreator = creator;
            
            _pool = objectPool;
            
            _platformCreator.AddPlatforms(out _platformsToAdd);

            for (int i = 0; i < platformsOnStart; i++)
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
            _pool.AddPlatforms(_platformsToAdd[stage]);
            _maxYOffset += _gameStagesConfig.ExtraYOffsetPerStage[stage];
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

    }
}