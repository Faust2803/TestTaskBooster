using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonAnimation: MonoBehaviour
    {
        [SerializeField] private Animator  _animator;
        [SerializeField] private Button  _button;

        private void Start()
        {
            _button.onClick.AddListener(() => _animator.SetTrigger("Pressed"));
        }

        private void OnDestroy()
        {
           _button.onClick.RemoveAllListeners();
        }
    }
}