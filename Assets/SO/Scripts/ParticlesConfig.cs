using UnityEngine;

namespace SO.Scripts
{
    [CreateAssetMenu(fileName = "ParticlesConfig", menuName = "Configs/UI/SO Particles Config", order = 1)]
    public class ParticlesConfig : ScriptableObject
    {
        public  GameObject [] ParticlePrefab = null;
    }
}