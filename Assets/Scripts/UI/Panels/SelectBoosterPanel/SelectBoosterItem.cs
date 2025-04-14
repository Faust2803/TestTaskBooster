using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class SelectBoosterItem:MonoBehaviour
    {
        [SerializeField] private GameObject  _boosterBacklight;
        [SerializeField] private Image  _boosterImage;
        [SerializeField] private Button  _choiceButton;
        
        public GameObject  BoosterBacklight => _boosterBacklight;
        public Image  BoosterImage => _boosterImage;
        public Button  ChoiceButton => _choiceButton;
        
        public BoosterType Type { get; private set; }
        

        public void SetBoosterType(BoosterType type)
        {
            Type = type;
        }
    }
}