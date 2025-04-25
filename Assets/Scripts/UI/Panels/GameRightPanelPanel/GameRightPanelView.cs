using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameRightPanelView : BasePanelView
    {
        [Space]
        [SerializeField] private Button  _noTernButton;
        [SerializeField] private Button  _leftTernButton;
        [SerializeField] private Button  _rightTernButton;
        [SerializeField] private Button  _fireButton;
        
        public Button  NoTernButton => _noTernButton;
        public Button  LeftTernButton => _leftTernButton;
        public Button  RightTernButton => _rightTernButton;
        public Button  FireButton => _fireButton;
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameRightPanelPanelMediator();
            return _mediator;
        }
    }
}