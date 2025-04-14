using UnityEngine;
using Zenject;

namespace SO.Scripts
{
    [CreateAssetMenu (fileName = "SoInstaller", menuName = "Configs/Create SO Installer", order = 0 )]
    public class SoInstaller : ScriptableObjectInstaller<SoInstaller>
    {
        [SerializeField] public WindowsConfig _windowsConfig;
        [SerializeField] public PanelsConfig _panelConfig;
        [SerializeField] public ParticlesConfig _particlesConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_windowsConfig).IfNotBound();
            Container.BindInstance(_panelConfig).IfNotBound();
            Container.BindInstance(_particlesConfig).IfNotBound();
        }
    }
}