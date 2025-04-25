
using System;

namespace UI.Panels
{
    public class GameRightPanelPanelMediator :BasePanelMediator <GameRightPanelView, UIData>
    {
        public event Action<TernType> OnChangeTern;  
        public event Action<FireTernType> OnFire;  
        protected override void OpenFinish()
        {
            base.OpenFinish();
            Target.LeftTernButton.onClick.AddListener(()=> OnChangeTern.Invoke(TernType.Left));
            Target.RightTernButton.onClick.AddListener(()=> OnChangeTern.Invoke(TernType.Right));
            Target.NoTernButton.onClick.AddListener(()=> OnChangeTern.Invoke(TernType.None));
            Target.FireButton.onClick.AddListener(()=> OnFire.Invoke(FireTernType.Left));
        }
        
        protected override void CloseStart()
        { 
            base.CloseStart();
            Target.LeftTernButton.onClick.RemoveAllListeners();
            Target.RightTernButton.onClick.RemoveAllListeners();
            Target.NoTernButton.onClick.RemoveAllListeners();
            Target.FireButton.onClick.RemoveAllListeners();
        }
    }
}