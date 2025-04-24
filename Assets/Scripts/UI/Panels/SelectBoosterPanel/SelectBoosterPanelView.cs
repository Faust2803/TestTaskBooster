using SO.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class SelectBoosterPanelView : BasePanelView
    {
        [SerializeField] private GameObject  _boosterArea;
        [SerializeField] private Button  _okButton;
        [SerializeField] private Button  _resetButton;
        [SerializeField] private float  _animationTime = 0.5f;
        [Space]
        [SerializeField] private SelectBoosterItem[] _selectBoosterItem = new SelectBoosterItem[3];
        [SerializeField] private SelectBoosterItem  _animatedBooster;
        [Space] 
        [SerializeField] private BoosterConfig _boosterSprites;
        
        public GameObject  BoosterArea => _boosterArea;
        public Button  OkButton => _okButton;
        public Button  ResetButton => _resetButton;
        public float  AnimationTime => _animationTime;
        public SelectBoosterItem[]  SelectBoosterItem => _selectBoosterItem;
        public SelectBoosterItem  AnimatedBooster => _animatedBooster;
        public BoosterConfig  BoosterSprites => _boosterSprites;
       
        protected override void CreateMediator()
        {
            _mediator = new SelectBoosterMediator();
            _mediator = new GameCompassPanelMediator();
        }
    }
}