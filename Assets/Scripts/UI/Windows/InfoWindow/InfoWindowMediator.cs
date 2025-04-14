using UnityEngine;

namespace UI.Windows

{
    public class InfoWindowMediator : BaseWindowMediator<InfoWindowView, WData>
    {
        
        protected override void ShowStart()
        {
            base.ShowStart();
            
            Debug.Log(Data);
            Debug.Log(_data);
            
        }
    }
}