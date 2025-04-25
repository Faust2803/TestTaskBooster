using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameLeftPanelView : BasePanelView
    {
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameLeftPanelPanelMediator();
            return _mediator;
        }
    }
}