using Managers;
using UnityEngine;
using Zenject;
namespace Installers
{
    public class ManagersInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            //Bind Manager
            Container.BindInterfacesAndSelfTo<UiManager>().AsSingle().NonLazy();
        }
    }
}