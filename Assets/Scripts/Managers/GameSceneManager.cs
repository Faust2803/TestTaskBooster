using UI.Panels;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameSceneManager : MonoBehaviour
    {
        [Inject] private UiManager _uiManager;

        private GameBottomPanelMediator _gameBottomPanel;
        private GameCompassPanelMediator _gameCompassPanel;
        private GameLeftPanelPanelMediator _gameLeftPanelPanel;
        private GameRightPanelPanelMediator _gameRightPanelPanel;
        private GameTopPanelMediator _gameTopPanel;
        
        
        private void Start()
        {
            _gameBottomPanel =_uiManager.OpenPanel(PanelType.GameBottomPanel) as GameBottomPanelMediator;
            _gameCompassPanel =_uiManager.OpenPanel(PanelType.GameCompassPanel) as GameCompassPanelMediator;
            _gameLeftPanelPanel =_uiManager.OpenPanel(PanelType.GameLeftPanel) as GameLeftPanelPanelMediator;
            _gameRightPanelPanel =_uiManager.OpenPanel(PanelType.GameRightPanel) as GameRightPanelPanelMediator;
            _gameTopPanel =_uiManager.OpenPanel(PanelType.GameTopPanel) as GameTopPanelMediator;
        }
    }
}
