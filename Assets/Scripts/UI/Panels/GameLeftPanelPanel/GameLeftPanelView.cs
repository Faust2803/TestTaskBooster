using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameLeftPanelView : BasePanelView
    {
        [Space]
        [SerializeField] private Button  _fullSpeedButton;
        [SerializeField] private Button  _halfSpeedButton;
        [SerializeField] private Button  _stopButton;
        [SerializeField] private Button  _fireButton;
        
        public Button  FullSpeedButton => _fullSpeedButton;
        public Button  HalfSpeedButton => _halfSpeedButton;
        public Button  StopButton => _stopButton;
        public Button  FireButton => _fireButton;
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameLeftPanelPanelMediator();
            return _mediator;
        }
    }
}