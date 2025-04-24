using UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public abstract class BasePanelView : BaseView
    {

        protected BasePanelMediator _mediator;

        public BasePanelMediator BaseMediator => _mediator;

        public GameObject Panel => this.gameObject;

        public void OnCreateMediator(out BasePanelMediator mediator)
        {
            mediator = _mediator;
        }
        
        [Space]
        [SerializeField] private Button  _moveButton;
        [SerializeField] private GameObject  _movePanel;
        [SerializeField] private float  _offset;
        [SerializeField] private PanelMoveDirection  _moveDirection;
        
       
        public Button  MoveButton => _moveButton;
        public GameObject  MovePanel => _movePanel;
        public float  Offset => _offset;
        public PanelMoveDirection  MoveDirection => _moveDirection;
        
        
        public override void Init()
        {
            base.Init();
            _mediator.Mediate(this);
        }
    }
    
    public enum PanelMoveDirection
    {
        Top,
        Bottom,
        Left,
        Right
    }
}