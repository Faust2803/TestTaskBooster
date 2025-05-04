using System.Collections.Generic;
using SO.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class BoostersView : BasePanelView
    {
        [SerializeField] private GameObject  _slidingPanel;
        [SerializeField] private Button  _slidingButton;
        
        [SerializeField] private GameObject  _lock;
        [Space]
        [SerializeField] private BoosterItem[] _boosterItem = new BoosterItem[4];
        [Space] 
        [SerializeField] private BoosterConfig _boosterSprites;
        [Space]
        [SerializeField] private GameObject  _boosterPanel;
        [SerializeField] private SelectBoosterItem _selectBoosterItem;
        [SerializeField] private GameObject  _chekmark;
        [SerializeField] private float  _moveBoosterAnimationTome = 3F;
        [SerializeField] private List<Transform>  _path;
        
        protected override BaseMediator CreateMediator()
        {
            _mediator = new BoostersPanelMediator();
            return _mediator;
        }
        public GameObject  SlidingPanel => _slidingPanel;
        public Button  SlidingButton => _slidingButton;
        public GameObject  Lock => _lock;
        public BoosterConfig  BoosterSprites => _boosterSprites;
        public BoosterItem[]  BoosterItem => _boosterItem;
        public GameObject  BoosterPanel => _boosterPanel;
        public SelectBoosterItem  SelectBoosterItem => _selectBoosterItem;
        public GameObject  Chekmark => _chekmark;
        public float  MoveBoosterAnimationTome => _moveBoosterAnimationTome;
        public List<Transform>  Path => _path;
        

        

    }
}