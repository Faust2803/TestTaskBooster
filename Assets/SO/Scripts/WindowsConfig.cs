using UnityEngine;

namespace SO.Scripts
{
    [CreateAssetMenu(fileName = "WindowsConfig", menuName = "Configs/UI/SO Windows Config", order = 1)]
    public class WindowsConfig : ScriptableObject
    {
        public  GameObject [] WindowsPrefab = null;
    }
}