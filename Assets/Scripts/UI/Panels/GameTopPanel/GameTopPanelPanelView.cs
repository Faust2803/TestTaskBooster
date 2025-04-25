using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panels
{
    public class GameTopPanelView : BasePanelView
    {
        [Space]
        [SerializeField] private Button  _bulletButton;
        [SerializeField] private TextMeshProUGUI  _bulletText;
        [Space]
        [SerializeField] private Button  _knipelButton;
        [SerializeField] private TextMeshProUGUI  _knipelText;
        [Space]
        [SerializeField] private Button  _buckshotButton;
        [SerializeField] private TextMeshProUGUI  _buckshotText;
        [Space]
        [SerializeField] private Button  _grenadeButton;
        [SerializeField] private TextMeshProUGUI  _grenadeText;
        public Button  BulletButton => _bulletButton;
        public TextMeshProUGUI  BulletText => _bulletText;
        public Button  KnipelButton => _knipelButton;
        public TextMeshProUGUI  KnipelText => _knipelText;
        public Button  BuckshotButton => _buckshotButton;
        public TextMeshProUGUI  BuckshotText => _buckshotText;
        public Button  GrenadeButton => _grenadeButton;
        public TextMeshProUGUI  GrenadeText => _grenadeText;
        protected override BaseMediator CreateMediator()
        {
            _mediator = new GameTopPanelMediator();
            return _mediator;
        }
    }
}