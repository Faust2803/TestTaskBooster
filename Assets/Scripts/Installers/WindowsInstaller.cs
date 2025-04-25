using SO.Scripts;
using UI;
using UI.Windows;
using Util;
using Zenject;

namespace Installers
{
    public class WindowsInstaller : MonoInstaller
    {
        [Inject] private WindowsConfig _windowsConfig;
        
        public override void InstallBindings()
        {
            //Bind Factory
            Container.BindFactory< WindowType, BaseView, FactoryWindow>().FromMethod(InitWindow);
        }

        private BaseView InitWindow(DiContainer container, WindowType window)
        {
            var level = _windowsConfig.WindowsPrefab[(int)window];
            return Container.InstantiatePrefabForComponent<BaseView>(level);
        }
    }
}