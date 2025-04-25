using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameBottomPanelView : BasePanelView
    {
        [Space]
        [SerializeField] private Button  _normalViewButton;
        [SerializeField] private Button  _farViewButton;
        [SerializeField] private Button  _forvardViewButton;
        [SerializeField] private Button  _leftViewButton;
        [SerializeField] private Button  _rightViewButton;
        [SerializeField] private Button  _backViewButton;
        
        public Button  NormalViewButton => _normalViewButton;
        public Button  FarViewButton => _farViewButton;
        public Button  ForvardViewButton => _forvardViewButton;
        public Button  LeftViewButton => _leftViewButton;
        public Button  RightViewButton => _rightViewButton;
        public Button  BackViewButton => _backViewButton;
        
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameBottomPanelMediator();
            return _mediator;
        }
    }
}