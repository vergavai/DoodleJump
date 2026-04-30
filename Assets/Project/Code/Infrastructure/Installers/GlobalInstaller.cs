using Project.Code.UI.Menu.StartMenu;
using Zenject;

namespace Project.Code.Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<GameSceneLoader>()
                .FromNew()
                .AsSingle();
        }
    }
}