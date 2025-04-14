using SO.Scripts;
using UI.Windows;
using UnityEngine;
using Util;
using Zenject;

namespace Installers
{
    public class ParticleInstaller : MonoInstaller
    {
        [Inject] private ParticlesConfig _particlesConfig;
        
        public override void InstallBindings()
        {
            //Bind Factory
            Container.BindFactory<ParticlesType, GameObject, FactoryParticle>().FromMethod(InitParticle);
        }

        private GameObject InitParticle(DiContainer container, ParticlesType particleType)
        {
            var level = _particlesConfig.ParticlePrefab[(int)particleType];
            return Container.InstantiatePrefab(level);
        }
    }
}