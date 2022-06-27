using Windows;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "DatabasesSO/Installers/UiPrefabsInstaller")]
    public class PrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CanvasView _canvasView;
        [SerializeField] private MainWindowView _mainWindowView;
        
        public override void InstallBindings()
        {
            Container.Bind<CanvasView>().FromComponentInNewPrefab(_canvasView).AsSingle();
            Container.Bind<MainWindowView>().FromComponentInNewPrefab(_mainWindowView).AsSingle();
        }
    }
}