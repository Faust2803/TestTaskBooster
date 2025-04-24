using UnityEngine;

namespace UI.Panels
{
    public class GameCompassPanelView : BasePanelView
    {
        [SerializeField] private GameObject  _compass;
        public GameObject  Compass => _compass;
       
        protected override void CreateMediator()
        {
            _mediator = new GameCompassPanelMediator();
        }
    }
}