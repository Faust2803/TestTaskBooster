using UI;
using UI.Panels;
using UI.Windows;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class SceneManager : MonoBehaviour
    {
        [Inject] private UiManager _uiManager;

        private SelectBoosterMediator _selectBoosterPanel;
        private BoostersPanelMediator _boostersPanel;
        
        private void Start()
        {
            var boosterItems = new BoosterItemData[4]
            {
                new BoosterItemData
                {
                    Lock = false,
                },
                new BoosterItemData(),
                new BoosterItemData(),
                new BoosterItemData()
            };
            
            
            _uiManager.OpenPanel(PanelType.BoostersPanel, 
                new BoostersData {
                    BoosterItems = boosterItems
                }
            ) ;
            
           _uiManager.OpenPanel(PanelType.SelectBoosterPanel);
           
            if (_selectBoosterPanel != null)
            {
                _selectBoosterPanel.OnAnimationFinished += OnSelectAnimationFinished;
            }
            if (_boostersPanel != null)
            {
                _boostersPanel.OnAnimationFinished += OnMoveBoostertAnimationFinished;
            }
           
            //_uiManager.OpenWindow(WindowType.InfoWindow);
        }

        private void OnSelectAnimationFinished(BoosterType type)
        {
            _boostersPanel.SelectAnimationFinished(type);
        }
        
        private void OnMoveBoostertAnimationFinished()
        {
            _selectBoosterPanel.MoveBoostertAnimationFinished();
        }

        private void OnDestroy()
        {
            if (_selectBoosterPanel != null)
            {
                _selectBoosterPanel.OnAnimationFinished -= OnSelectAnimationFinished;
            }
            if (_boostersPanel != null)
            {
                _boostersPanel.OnAnimationFinished -= OnMoveBoostertAnimationFinished;
            }
        }
    }
}
