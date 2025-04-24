using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameRightPanelView : BasePanelView
    {
        [SerializeField] private Button  _okButton;
        
        public Button  OkButton => _okButton;
       
        protected override void CreateMediator()
        {
            _mediator = new GameRightPanelPanelMediator();
        }
    }
}