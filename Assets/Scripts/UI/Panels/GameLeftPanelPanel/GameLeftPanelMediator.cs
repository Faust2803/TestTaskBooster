

using System;

namespace UI.Panels
{
    public class GameLeftPanelPanelMediator :BasePanelMediator <GameLeftPanelView, UIData>
    {
        public event Action<SpeedType> OnChangeSpeed;  
        public event Action<FireTernType> OnFire;  
        protected override void OpenFinish()
        {
            base.OpenFinish();
            Target.FullSpeedButton.onClick.AddListener(()=> OnChangeSpeed.Invoke(SpeedType.Full));
            Target.HalfSpeedButton.onClick.AddListener(()=> OnChangeSpeed.Invoke(SpeedType.Half));
            Target.StopButton.onClick.AddListener(()=> OnChangeSpeed.Invoke(SpeedType.Stop));
            Target.FireButton.onClick.AddListener(()=> OnFire.Invoke(FireTernType.Left));
        }
        
        protected override void CloseStart()
        { 
            base.CloseStart();
            Target.FullSpeedButton.onClick.RemoveAllListeners();
            Target.HalfSpeedButton.onClick.RemoveAllListeners();
            Target.StopButton.onClick.RemoveAllListeners();
            Target.FireButton.onClick.RemoveAllListeners();
        }
    }
}