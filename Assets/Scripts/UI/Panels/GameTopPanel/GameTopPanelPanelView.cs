using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameTopPanelView : BasePanelView
    {
        protected override void CreateMediator()
        {
            _mediator = new GameTopPanelMediator();
        }
    }
}