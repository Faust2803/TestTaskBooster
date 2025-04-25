using UnityEngine.UI;

namespace UI.Windows
{
    public class InfoWindowView : BaseView
    {
        protected override BaseMediator CreateMediator()
        {
            _mediator = new InfoWindowMediator();
            return _mediator;
        }
    }
}