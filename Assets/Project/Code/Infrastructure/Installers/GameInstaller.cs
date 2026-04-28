using Project.Code.Gameplay.InputLogic;
using Project.Code.Gameplay.Platforms;
using Project.Code.Gameplay.Player;
using Project.Code.Gameplay.Player.Movement;
using Project.Code.Gameplay.Player.PlayerDeathLogic;
using Project.Code.Gameplay.Player.ScoreLogic;
using Project.Code.Infrastructure.AdsLogic;
using UnityEngine;
using Zenject;

namespace Project.Code.Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform _location;
        [SerializeField] private GameObject _playerPrefab;
        
        public override void InstallBindings()
        {
            BindPlayerInput();
            BindPlatformDetector();
            BindPlayerDeath();
            BindAndInstantiatePlayer();
            BindPlayerScore();
            BindPlayerDoubleJump();
            BindSignals();
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
    }
}