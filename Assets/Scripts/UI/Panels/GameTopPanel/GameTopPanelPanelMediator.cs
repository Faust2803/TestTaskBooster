using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace UI.Panels
{
    public class GameTopPanelMediator :BasePanelMediator <GameTopPanelView, UIData>
    {
        public event Action<FireType> OnFireTypeChanged;  
        protected override void OpenFinish()
        {
            base.OpenFinish();
            Target.BulletButton.onClick.AddListener(()=> OnFireTypeChanged.Invoke(FireType.Bullet));
            Target.KnipelButton.onClick.AddListener(()=> OnFireTypeChanged.Invoke(FireType.Knipel));
            Target.BuckshotButton.onClick.AddListener(()=> OnFireTypeChanged.Invoke(FireType.Buckshot));
            Target.GrenadeButton.onClick.AddListener(()=> OnFireTypeChanged.Invoke(FireType.Grenade));
        }
        
        protected override void CloseStart()
        { 
            base.CloseStart();
            Target.BulletButton.onClick.RemoveAllListeners();
            Target.KnipelButton.onClick.RemoveAllListeners();
            Target.BuckshotButton.onClick.RemoveAllListeners();
            Target.GrenadeButton.onClick.RemoveAllListeners();
        }

        public void SetAmmo(FireType fireType, int ammo)
        {
            switch (fireType)
            {
                case FireType.Bullet:
                    Target.BulletText.text = ammo.ToString();
                    break;
                case FireType.Knipel:
                    Target.KnipelText.text = ammo.ToString();
                    break;
                case FireType.Buckshot:
                    Target.BuckshotText.text = ammo.ToString();
                    break;
                case FireType.Grenade:
                    Target.GrenadeText.text = ammo.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fireType), fireType, null);
            }
        }
    }
}