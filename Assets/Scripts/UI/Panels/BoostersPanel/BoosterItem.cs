using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class BoosterItem : MonoBehaviour
    {
        [SerializeField] private GameObject  _empty;
        [SerializeField] private GameObject  _lock;
        [SerializeField] private Image  _booster;
        
        public GameObject  Empty => _empty;
        public GameObject  Lock => _lock;
        public Image  Booster => _booster;

    }
}