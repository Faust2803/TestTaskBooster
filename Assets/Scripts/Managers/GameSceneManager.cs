using System;
using System.Collections.Generic;
using Game;
using UI.Panels;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameSceneManager : MonoBehaviour
    {
        [Inject] private UiManager _uiManager;
        
        [SerializeField] private Player _player;

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

            _gameBottomPanel.OnChangeView += OnChangeCameraView;
            _gameLeftPanelPanel.OnChangeSpeed += SetSpeed;
            _gameLeftPanelPanel.OnFire += SetFire;
            _gameRightPanelPanel.OnFire += SetFire;
            _gameRightPanelPanel.OnChangeTern += SetTern;
            _gameTopPanel.OnFireTypeChanged += OnFireTypeChanged;
            _player.OnAmmoChanged += OnAmmoChanged;
            _player.SetCompass(_gameCompassPanel.Compass);
            
            _player.StartGame();
        }

        private void OnChangeCameraView(CameraPositionType position)
        {
            _player.SetCameraPosition(position);
        }
        private void SetSpeed(SpeedType type)
        {
            _player.SetSpeed(type);
        }
        private void SetTern(TernType type)
        {
            _player.SetTern(type);
        }
        private void SetFire(FireTernType ternType)
        {
            _player.SetFire(ternType);
        }
        
        private void OnFireTypeChanged(FireType type)
        {
            _player.OnFireTypeChanged(type);
        }
        
        private void OnAmmoChanged(FireType type, int ammo, List<Canon> cannon)
        {
            _gameTopPanel.SetAmmo(type, ammo);
        }

        private void OnDestroy()
        {
            _gameBottomPanel.OnChangeView -= OnChangeCameraView;
            _gameLeftPanelPanel.OnChangeSpeed -= SetSpeed;
            _gameLeftPanelPanel.OnFire -= SetFire;
            _gameRightPanelPanel.OnFire -= SetFire;
            _gameRightPanelPanel.OnChangeTern -= SetTern;
            _gameTopPanel.OnFireTypeChanged -= OnFireTypeChanged;
            _player.OnAmmoChanged -= OnAmmoChanged;
        }
    }
}
