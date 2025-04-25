using System;
using Managers;
using Zenject;


namespace UI
{
    public class BaseMediator
    {
        protected Action _afterCloseCallback;
        protected object _data;
        protected UiManager _uiManager;
        public  BaseMediator()
        {
            ProjectContext.Instance.Container.Inject(this);
        }
        
        protected BaseView BaseView { get; private set; }
        
        public virtual void SetData(object data)
        {
            _data = data;
        }
        
        public virtual void Mediate(BaseView value, UiManager uiManager)
        {
            BaseView = value;
            _uiManager = uiManager;
        }
        
        protected virtual void CloseFinish()
        { 
            BaseView.Close();
            if (_afterCloseCallback!= null)
            {
                _afterCloseCallback.Invoke();
            }
        }
        
        protected virtual void OpenFinish()
        {

        }
    }
}