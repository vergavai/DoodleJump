using System.Collections.Generic;
using Project.Code.Configs;
using Project.Code.Gameplay.Platforms;
using UnityEngine;

namespace Project.Code.Gameplay.ObjectGenerator
{
    public class PlatformCreator
    {
        private PlatformFactory _platformFactory;
        private MovingPlatformFactory _movingPlatformFactory;
        private PlatformGeneratorConfig _generatorConfig;
        private GameStagesConfig _gameStagesConfig;
        private Transform _platformContainer;
        private ObjectPool _pool;

        public PlatformCreator(PlatformFactory platformFactory, MovingPlatformFactory movingPlatformFactory,
            PlatformGeneratorConfig generatorConfig, GameStagesConfig gameStagesConfig, 
            PlatformContainer platformContainer, ObjectPool pool)
        {
            _platformFactory = platformFactory;
            _movingPlatformFactory = movingPlatformFactory;
            _generatorConfig = generatorConfig;
            _gameStagesConfig = gameStagesConfig;
            _platformContainer = platformContainer.Container;
            _pool = pool;
        }

        public void AddPlatforms(out List<List<GameObject>> platformsToAdd)
        {
            CreateAndAddPlatforms(_generatorConfig.PlatformPrefab, _generatorConfig.PlatformsCount,
                _platformContainer);
            CreateAndAddPlatforms(_generatorConfig.SpringPrefab, _generatorConfig.SpringsCount,
                _platformContainer);
            CreateAndAddPlatforms(_generatorConfig.BreakablePlatformPrefab, _generatorConfig.BreakablePlatformsCount,
                _platformContainer);
            
            CreateStagePlatforms(out platformsToAdd);
        }

        private void CreateAndAddPlatforms(GameObject prefab, int count, Transform parent)
        {
            List<Platform> platforms = _platformFactory.CreateMany(prefab, count, parent);

            List<GameObject> platformObjects = new List<GameObject>();

            for (int i = 0; i < platforms.Count; i++)
            {
                platformObjects.Add(platforms[i].gameObject);
            }

            _pool.AddPlatforms(platformObjects);
        }

        private void CreateStagePlatforms(out List<List<GameObject>> platformsToAdd)
        {
            List<List<GameObject>> result = new List<List<GameObject>>();
            
            for (int i = 0; i < _gameStagesConfig.StagesCount; i++)
            {
                List<MovingPlatform> movingPlatforms = _movingPlatformFactory
                    .CreateMany(_gameStagesConfig.ObjectsToAddPerStage[i], _platformContainer);

                List<GameObject> platformObjects = new List<GameObject>();

                for (int j = 0; j < movingPlatforms.Count; j++)
                {
                    platformObjects.Add(movingPlatforms[j].gameObject);
                }

                result.Add(platformObjects);
            }
            
            platformsToAdd = result;
        }
    }
}