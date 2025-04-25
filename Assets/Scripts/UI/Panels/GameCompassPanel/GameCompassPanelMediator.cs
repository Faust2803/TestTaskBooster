

using UnityEngine;

namespace UI.Panels
{
    public class GameCompassPanelMediator :BasePanelMediator <GameCompassPanelView, UIData>
    {
        public GameObject Compass => Target.Compass;
    }
}