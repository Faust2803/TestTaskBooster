using UnityEngine;

namespace SO.Scripts
{
    [CreateAssetMenu(fileName = "BoosterConfig", menuName = "Configs/UI/SO Booster Config", order = 0)]
    public class BoosterConfig : ScriptableObject
    {
        public  Sprite [] Boosters = null;
    }
}