using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameTopPanelView : BasePanelView
    {
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameTopPanelMediator();
            return _mediator;
        }
    }
}