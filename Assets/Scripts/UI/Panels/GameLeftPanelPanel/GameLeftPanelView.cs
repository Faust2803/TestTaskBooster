using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameLeftPanelView : BasePanelView
    {
        [SerializeField] private Button  _okButton;
        
        
        public Button  OkButton => _okButton;
        
       
        protected override void CreateMediator()
        {
            _mediator = new GameLeftPanelPanelMediator();
        }
    }
}