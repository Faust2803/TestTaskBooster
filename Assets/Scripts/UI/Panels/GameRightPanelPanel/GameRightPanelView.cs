using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameRightPanelView : BasePanelView
    {
       
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameRightPanelPanelMediator();
            return _mediator;
        }
    }
}