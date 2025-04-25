using UnityEngine;

namespace UI.Panels
{
    public class GameCompassPanelView : BasePanelView
    {
        [SerializeField] private GameObject  _compass;
        public GameObject  Compass => _compass;
       
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameCompassPanelMediator();
            return _mediator;
        }
    }
}