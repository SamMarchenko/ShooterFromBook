using Windows;
using UISystem;
using Zenject;

namespace DefaultNamespace
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Windows();
        }

        private void Windows()
        {
            Container.BindInterfacesTo<CanvasContainer>().AsSingle();
            Container.BindInterfacesTo<UiAttachSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainWindowPresenter>().AsSingle();
        }
    }
}