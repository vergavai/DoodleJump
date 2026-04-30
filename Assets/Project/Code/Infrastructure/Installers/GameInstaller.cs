using Project.Code.Configs;
using Project.Code.Gameplay.GameBounds;
using Project.Code.Gameplay.GameStages;
using Project.Code.Gameplay.Input;
using Project.Code.Gameplay.ObjectGenerator;
using Project.Code.Gameplay.Platforms;
using Project.Code.Gameplay.Player.Death;
using Project.Code.Gameplay.Player.Movement;
using Project.Code.Gameplay.Player.Score;
using UnityEngine;
using Zenject;

namespace Project.Code.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlatformGenerator _platformGenerator;
        [SerializeField] private Transform _location;
        [SerializeField] private Transform _platformContainer;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private GameStagesConfig _gameStagesConfig;
        [SerializeField] private PlatformGeneratorConfig _platformGeneratorConfig;
        [SerializeField] private Camera _camera;
        
        public override void InstallBindings()
        {
            BindSignals();
            BindConfigs();
            BindCamera();
            BindObjectPool();
            BindPlayerInput();
            BindPlatformDetector();
            BindPlayerDeath();
            BindPlayerScore();
            BindPlayerDoubleJump();
            BindPlayerMovement();
            BindPlatformFactories();
            BindPlatformCreator();
            BindPlatformGenerator();
            BindStageProgression();
            BindAndInstantiatePlayer();
            BindGameBounds();
        }

        private void BindGameBounds()
        {
            Container.Bind<GameBounds>()
                .FromNew()
                .AsSingle();
        }

        private void BindPlatformCreator()
        {
            Container.Bind<PlatformCreator>()
                .FromNew()
                .AsSingle();
        }

        private void BindPlatformFactories()
        {
            Container.BindFactory<GameObject, Platform, PlatformFactory>()
                .FromFactory<PrefabFactory<Platform>>();
                
            Container.BindFactory<MovingPlatform, MovingPlatformFactory>()
                .FromComponentInNewPrefab(_platformGeneratorConfig.MovingPlatformPrefab)
                .OnInstantiated<MovingPlatform>((_, obj) => obj.gameObject.SetActive(false));
        }

        private void BindPlayerMovement()
        {
            Container.Bind<PlayerMovement>()
                .FromNew()
                .AsSingle();
        }

        private void BindStageProgression()
        {
            Container.Bind<StageProgression>()
                .FromNew()
                .AsSingle();
        }

        private void BindPlatformGenerator()
        {
            Container.Bind<PlatformGenerator>()
                .FromInstance(_platformGenerator)
                .AsSingle();
        }

        private void BindObjectPool()
        {
            Container.Bind<PlatformContainer>()
                .FromInstance(new PlatformContainer(_platformContainer))
                .AsSingle();

            Container.Bind<ObjectPool>()
                .FromNew()
                .AsSingle();
        }

        private void BindCamera()
        {
            Container.Bind<Camera>()
                .FromInstance(_camera)
                .AsSingle();
        }

        private void BindPlayerDoubleJump()
        {
            Container.Bind<PlayerDoubleJumpBehaviour>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void BindAndInstantiatePlayer()
        {
            Container.Bind<PlayerMovementBehaviour>()
                .FromComponentInNewPrefab(_playerPrefab)
                .AsSingle()
                .OnInstantiated<PlayerMovementBehaviour>(SetPlayerPosition)
                .NonLazy();
        }

        private void BindPlayerInput()
        {
            Container
                .Bind<PlayerInput>()
                .FromNew()
                .AsSingle();
        }
        
        private void BindPlatformDetector()
        {
            Container
                .Bind<PlatformDetector>()
                .FromNew()
                .AsSingle();
        }

        private void BindPlayerScore()
        {
            Container
                .Bind<PlayerScore>()
                .FromNew()
                .AsSingle();
            
            Container
                .Bind<ScoreObserver>()
                .FromNew()
                .AsSingle();
        }
        
        private void SetPlayerPosition(InjectContext context, PlayerMovementBehaviour player)
        {
            player.transform.position = _location.position;
        }

        private void BindPlayerDeath()
        {
            Container.Bind<PlayerDeath>()
                .FromNew()
                .AsSingle();
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerDiedSignal>();
        }

        private void BindConfigs()
        {
            Container.Bind<PlayerConfig>()
                .FromInstance(_playerConfig)
                .AsSingle();
            Container.Bind<GameStagesConfig>()
                .FromInstance(_gameStagesConfig)
                .AsSingle();
            Container.Bind<PlatformGeneratorConfig>()
                .FromInstance(_platformGeneratorConfig)
                .AsSingle();
        }
    }
}