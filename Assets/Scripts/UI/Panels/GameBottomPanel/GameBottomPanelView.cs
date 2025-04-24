using SO.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameBottomPanelView : BasePanelView
    {
        protected override void CreateMediator()
        {
            _mediator = new GameBottomPanelMediator();
        }
    }
}