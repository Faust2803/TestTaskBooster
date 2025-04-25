using System;

namespace UI.Panels
{
    public class GameBottomPanelMediator :BasePanelMediator <GameBottomPanelView, UIData>
    {
        public event Action<CameraPositionType> OnChangeView;  
        protected override void OpenFinish()
        {
            base.OpenFinish();
            Target.NormalViewButton.onClick.AddListener(()=>OnChangeView.Invoke(CameraPositionType.Normal));
            Target.FarViewButton.onClick.AddListener(()=>OnChangeView.Invoke(CameraPositionType.Far));
            Target.ForvardViewButton.onClick.AddListener(()=>OnChangeView.Invoke(CameraPositionType.Forvard));
            Target.LeftViewButton.onClick.AddListener(()=>OnChangeView.Invoke(CameraPositionType.Left));
            Target.RightViewButton.onClick.AddListener(()=>OnChangeView.Invoke(CameraPositionType.Right));
            Target.BackViewButton.onClick.AddListener(()=>OnChangeView.Invoke(CameraPositionType.Back));
        }
        
        protected override void CloseStart()
        { 
            base.CloseStart();
            Target.NormalViewButton.onClick.RemoveAllListeners();
            Target.FarViewButton.onClick.RemoveAllListeners();
            Target.ForvardViewButton.onClick.RemoveAllListeners();
            Target.LeftViewButton.onClick.RemoveAllListeners();
            Target.RightViewButton.onClick.RemoveAllListeners();
            Target.BackViewButton.onClick.RemoveAllListeners();
        }
        
        

       
    }
}