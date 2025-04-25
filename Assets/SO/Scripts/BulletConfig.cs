using UnityEngine;

namespace SO.Scripts
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Configs/Game/SO Bullet Config", order = 0)]
    public class BulletConfig : ScriptableObject
    {
        public  GameObject [] Boosters = null;
    }
}