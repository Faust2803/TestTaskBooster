using SO.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameBottomPanelView : BasePanelView
    {
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameBottomPanelMediator();
            return _mediator;
        }
    }
}