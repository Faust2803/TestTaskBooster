using System;
using System.Collections.Generic;
using DG.Tweening;
using Installers;
using UI.Windows;
using UnityEngine;
using Util;
using Zenject;

namespace UI.Panels
{
    public class BoostersPanelMediator : BasePanelMediator<BoostersView, BoostersData>
    {
        [Inject] private readonly FactoryParticle _factoryParticle;
        [Inject] private readonly ParticleInstaller _particlePool;
        
        public event Action OnAnimationFinished; 
        
        private float _slidingPanelPosition;
        private bool _isOpen = true;
        private Vector3 _selectBoosterItemPosition;
        private BoosterType _lastselectedBoosterType;
        private int _setedBoosterIndex;
        private List<Vector3> _path;
        private const float SELECTED_BOOSTER_SCALE = 1.2f;
        private ParticleSystem _selectedParticle;
        
        protected override void ShowStart()
        {
            base.ShowStart();
            Target.SlidingButton.onClick.AddListener(OnSlidingButton);
            _slidingPanelPosition = Target.SlidingPanel.transform.position.x;
            Target.BoosterPanel.SetActive(false);
            SetBoosters();

            _path = new List<Vector3>(Target.Path.Count);
            for (var i = 0; i < Target.Path.Count; i++)
            {
                _path.Add(Target.Path[i].transform.position);
            }

            _selectedParticle = LoadParticlePrefab(ParticlesType.GetBooster);
            var particlePosition = new Vector3(
                Target.SelectBoosterItem.transform.position.x,
                Target.SelectBoosterItem.transform.position.y,
                _selectedParticle.transform.position.z);
            _selectedParticle.transform.position = particlePosition;
        }

        public void SelectAnimationFinished(BoosterType type)
        {
            _lastselectedBoosterType = type;
            Target.SelectBoosterItem.BoosterImage.sprite = Target.BoosterSprites.Boosters[(int)type];
            _selectBoosterItemPosition =  Target.SelectBoosterItem.transform.position;
            
            Target.Chekmark.transform.localScale = Vector3.zero;
            Target.Chekmark.transform.DOScale(Vector3.one, Target.OpenCloseDuration).OnComplete(MoveToBoosterPanel);
            
            Target.BoosterPanel.SetActive(true);
            
            _selectedParticle.Play();

            if (!_isOpen)
            {
                OnSlidingButton();
            }
        }

        private void MoveToBoosterPanel()
        {
            _setedBoosterIndex = FinedEmptyBoosters();
            var movePosition = Target.BoosterItem[_setedBoosterIndex].transform.position;
            _path[^1] = movePosition;
            
            var seq = DOTween.Sequence();
            seq.Append(Target.SelectBoosterItem.transform.DOPath(_path.ToArray(), Target.MoveBoosterAnimationTome, PathType.CatmullRom));
            seq.Join(Target.SelectBoosterItem.transform.DOScale(Vector3.one * 0.5F, Target.MoveBoosterAnimationTome)
                .OnComplete(() =>
                {
                    MoveToBoosterPanelFinish();
                    DOVirtual.DelayedCall(Target.MoveBoosterAnimationTome, () =>
                    {
                        if (_setedBoosterIndex < Data.BoosterItems.Length)
                        {
                            Data.BoosterItems[_setedBoosterIndex + 1].Lock = false;
                            OnAnimationFinished?.Invoke();
                            SetBoosters();
                        }
                    });
                }));
            seq.Play();
        }

        private void MoveToBoosterPanelFinish()
        {
            Target.BoosterPanel.SetActive(false);
            Target.SelectBoosterItem.transform.position = _selectBoosterItemPosition;
            Target.SelectBoosterItem.transform.localScale = Vector3.one * SELECTED_BOOSTER_SCALE;
            
            Data.BoosterItems[_setedBoosterIndex].Empty = false;
            Data.BoosterItems[_setedBoosterIndex].BoosterType = _lastselectedBoosterType;
            SetBoosters();
        }

        private int FinedEmptyBoosters()
        {
            var boosterIndex = 0;
            for (var i = 0; i < Data.BoosterItems.Length; i++)
            {
                if (!Data.BoosterItems[i].Lock && Data.BoosterItems[i].Empty)
                {
                    boosterIndex = i;
                    break;
                }
            }
            return boosterIndex;
        }

        private void SetBoosters()
        {
            for (var i = 0; i < Target.BoosterItem.Length; i++)
            {
                Target.BoosterItem[i].Empty.SetActive(Data.BoosterItems[i].Empty);
                Target.BoosterItem[i].Lock.SetActive(Data.BoosterItems[i].Lock);
                if (Data.BoosterItems[i].BoosterType == BoosterType.None)
                {
                    Target.BoosterItem[i].Booster.gameObject.SetActive(false);
                }
                else
                {
                    Target.BoosterItem[i].Booster.gameObject.SetActive(true);
                    var type = Data.BoosterItems[i].BoosterType;
                    Target.BoosterItem[i].Booster.sprite = Target.BoosterSprites.Boosters[(int)type];
                }
            }
        }
        
        protected override void CloseStart()
        { 
            base.CloseStart();
            Target.SlidingButton.onClick.RemoveListener(OnSlidingButton);
        }

        private void OnSlidingButton()
        {
            Target.SlidingButton.interactable = false;

            if (_isOpen)
            {
                MovePanel(Target.Lock.transform.position.x);
            }
            else
            {
                MovePanel(_slidingPanelPosition);
            }
            _isOpen = !_isOpen;
        }
        
        private void MovePanel(float endPos)
        {
            Target.SlidingPanel.transform.DOMoveX(endPos, Target.OpenCloseDuration).OnComplete(AnimationFinish);
        }

        private void AnimationFinish()
        {
            Target.SlidingButton.interactable = true;
        }
        
        private ParticleSystem LoadParticlePrefab(ParticlesType type)
        {
            var view = _factoryParticle.Create(type);
            view.gameObject.transform.SetParent(_particlePool.transform,false);
            return view.GetComponent<ParticleSystem>();
        }
    }
}