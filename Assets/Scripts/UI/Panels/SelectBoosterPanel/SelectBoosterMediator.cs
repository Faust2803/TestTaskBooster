using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace UI.Panels
{
    public class SelectBoosterMediator :BasePanelMediator <SelectBoosterView, UIData>
    {
        private int _selectedBoosterIndex;
        private Vector3 _animatedBoosterPosition;
         public event Action<BoosterType> OnAnimationFinished;  
        
        protected override void ShowStart()
        {
            base.ShowStart();
            Target.OkButton.onClick.AddListener(OnOkButton);
            Target.ResetButton.onClick.AddListener(OnResetButton);
            
            for (var i = 0; i < Target.SelectBoosterItem.Length; i++)
            {
                var index = i;
                Target.SelectBoosterItem[i].ChoiceButton.onClick.AddListener(() =>
                {
                    OnSelectBooster(index);
                });
            }
            ResetPanel();
            _animatedBoosterPosition = Target.AnimatedBooster.transform.position;
        }
        
        protected override void CloseStart()
        { 
            base.CloseStart();
            Target.OkButton.onClick.RemoveListener(OnOkButton);
            Target.ResetButton.onClick.RemoveListener(OnResetButton);
            foreach (var t in Target.SelectBoosterItem)
            {
                t.ChoiceButton.onClick.RemoveAllListeners();
            }
        }

        public void MoveBoostertAnimationFinished()
        {
            ResetPanel();
        }

        private void OnOkButton()
        {
            Target.AnimatedBooster.gameObject.SetActive(true);
            Target.BoosterArea.gameObject.SetActive(false);
            Target.AnimatedBooster.transform.position = Target.SelectBoosterItem[_selectedBoosterIndex].transform.position;
            var type =  Target.SelectBoosterItem[_selectedBoosterIndex].Type;
            Target.AnimatedBooster.BoosterImage.sprite = Target.BoosterSprites.Boosters[(int)type];
            
            var seq = DOTween.Sequence();
            seq.Append(Target.AnimatedBooster.transform.DOMoveX(_animatedBoosterPosition.x, Target.AnimationTime));
            seq.Join(Target.AnimatedBooster.transform.DOMoveY(_animatedBoosterPosition.y, Target.AnimationTime));
            seq.Join(Target.AnimatedBooster.transform.DOScale(Vector3.one * 1.2F, Target.AnimationTime).OnComplete(AnimationFinish));
            seq.Play();
        }

        private void AnimationFinish()
        {
            OnAnimationFinished?.Invoke(Target.SelectBoosterItem[_selectedBoosterIndex].Type);
            Target.AnimatedBooster.transform.localScale = Vector3.one;
            Target.AnimatedBooster.gameObject.SetActive(false);
            Target.OkButton.gameObject.SetActive(false);
        }

        private void OnResetButton()
        {
            SetNewBoosters();
        }

        private void OnSelectBooster(int index)
        {
            for (var i = 0; i < Target.SelectBoosterItem.Length; i++)
            {
                if (i == index)
                {
                    Target.SelectBoosterItem[i].BoosterBacklight.SetActive(true);
                }
                else
                {
                    Target.SelectBoosterItem[i].BoosterBacklight.SetActive(false);
                }
            }
            Target.OkButton.gameObject.SetActive(true);
            _selectedBoosterIndex = index;
        }

        private void ResetPanel()
        {
            SetNewBoosters(true);
            Target.AnimatedBooster.gameObject.SetActive(false);
            Target.BoosterArea.gameObject.SetActive(true);
        }

        private void SetNewBoosters(bool animated = false)
        {
            foreach (var t in Target.SelectBoosterItem)
            {
                if (animated)
                {
                    SetBooster(t);
                }
                else
                {
                    var seq = DOTween.Sequence();
                    seq.Append(t.transform.DOScale(0f, 0.2f).OnComplete(() => SetBooster(t)));
                    seq.Append(t.transform.DOScale(1f, 0.2f));
                    seq.SetLoops(1);
                    seq.Play();
                }
                
            }
            Target.OkButton.gameObject.SetActive(false);
        }

        private void SetBooster(SelectBoosterItem t)
        {
            t.BoosterBacklight.SetActive(false);
            var result = GetRandomEnumExcluding(t.Type);
                
            t.BoosterImage.sprite = Target.BoosterSprites.Boosters[(int)result];
            t.SetBoosterType(result);
        }
        
        private T GetRandomEnumExcluding<T>(T exclude) where T : Enum
        {
            T[] values = Enum.GetValues(typeof(T)) as T[];
            T[] filtered = values.Where(v => !v.Equals(exclude)).ToArray();
            return filtered[UnityEngine.Random.Range(1, filtered.Length)];
        }
    }
}