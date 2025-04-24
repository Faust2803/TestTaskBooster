using System;
using DG.Tweening;
using UnityEngine;

namespace UI.Panels
{
    public class BasePanelMediator: BaseMediator
    {
        public BasePanelView PanelView { get; set; }
        
        private PanelType _panelType;
        
        private Vector3  _movePanelPosition;
        private bool _isOpen = true;
        private RectTransform _movePanelRectTransform;
        
        public PanelType PanelType => _panelType;
        public bool DeleteAfterClose => PanelView.DeleteAfterClose;

        public virtual void Mediate(BasePanelView value)
        {
            PanelView =  value;
            _moveto  = PanelView.Panel.transform.position.y;
        }
        
        public void SetType(PanelType windowType)
        {
            _panelType = windowType;
        }

        public virtual void Show()
        {
            ShowStart();
            PanelView.ShowStart();
        }
        
        public void Close(Action callback = null)
        {
            if (callback!= null)
            {
                _afterCloseCallback = callback;
            }
            CloseStart();
        }
        
        protected virtual void ShowStart()
        {
            if (PanelView.MoveButton != null)
            {
                PanelView.MoveButton.onClick.AddListener(OnMoveButton);
                _movePanelPosition = PanelView.MovePanel.transform.position;
                _movePanelRectTransform = PanelView.MovePanel.GetComponent<RectTransform>();
            }
            
            if (PanelView.Panel == null || !PanelView.OpenAnimation)
            {
                ShowEnd();
                return;
            }
            
            PanelView.Panel.transform.position = new Vector3(PanelView.Panel.transform.position.x,
                MOVE_POSITION,
                   PanelView.Panel.transform.position.z);
            PanelView.Panel.transform.DOMoveY(_moveto, ANIMATION_DURATION).OnComplete(ShowEnd);
        }
        
        protected virtual void ShowEnd()
        {

        }
        
        protected virtual void CloseStart()
        { 
            if (PanelView.Panel == null || !PanelView.CloseAnimation)
            {
                CloseFinish();
                return;
            }
            PanelView.Panel.transform.DOMoveY(MOVE_POSITION, ANIMATION_DURATION).OnComplete(CloseFinish);
            
            if (PanelView.MoveButton != null)
            {
                PanelView.MoveButton.onClick.RemoveListener(OnMoveButton);
            }
        }
        
        protected virtual void CloseFinish()
        { 
            PanelView.Close();
            if (_afterCloseCallback!= null)
            {
                _afterCloseCallback.Invoke();
            }
        }

        protected virtual void CloseSelf()
        {
            _uiManager.ClosePanel(_panelType);
        }
        
        private void OnMoveButton()
        {
            if (_isOpen)
            {
                MovePanel(GetMovePosition());
            }
            else
            {
                if (PanelView.MoveDirection == PanelMoveDirection.Top || PanelView.MoveDirection == PanelMoveDirection.Bottom)
                {
                    MovePanel(_movePanelPosition.y);
                }
                else
                {
                    MovePanel(_movePanelPosition.x);
                }
            }
            _isOpen = !_isOpen;
        }
        
        private void MovePanel(float endPos)
        {
            if (PanelView.MoveDirection == PanelMoveDirection.Top || PanelView.MoveDirection == PanelMoveDirection.Bottom)
            {
                PanelView.MovePanel.transform.DOMoveY(endPos, PanelView.OpenCloseDuration);
            }
            else
            {
                PanelView.MovePanel.transform.DOMoveX(endPos, PanelView.OpenCloseDuration);
            }
        }

        private float GetMovePosition()
        {
            var position = 0F;
            switch (PanelView.MoveDirection)
            {
                case PanelMoveDirection.Top:
                    position = PanelView.AnimationPanel.transform.position.y + _movePanelRectTransform.rect.height + PanelView.Offset;
                    break;
                case PanelMoveDirection.Bottom:
                    position = PanelView.AnimationPanel.transform.position.y - _movePanelRectTransform.rect.height - PanelView.Offset;
                    break;
                case PanelMoveDirection.Left:
                    position = PanelView.AnimationPanel.transform.position.x - _movePanelRectTransform.rect.width - PanelView.Offset;
                    break;
                case PanelMoveDirection.Right:
                    position = PanelView.AnimationPanel.transform.position.x + _movePanelRectTransform.rect.width + PanelView.Offset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return position;
        }
    }
    
    public abstract class BasePanelMediator<T, Z> : BasePanelMediator where T : BasePanelView where Z : UIData
    {
        public T Target => PanelView as T;

        public Z Data => _data as Z;
    }
}