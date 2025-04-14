using UnityEngine.UI;

namespace UI.Windows
{
    public class InfoWindowView : BaseWindowView
    {
        protected override void CreateMediator()
        {
            _mediator = new InfoWindowMediator();
        }
    }
}