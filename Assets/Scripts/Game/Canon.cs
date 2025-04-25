using System;
using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class Canon :MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private float _distance = 0.2F;
        [SerializeField] private float _duration = 0.5F;
        
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        public void Fire()
        {
            _particle.Play();
            var endPos = new Vector3(_startPosition.x + _distance, _startPosition.y, _startPosition.z);
            transform.DOMoveX(endPos.x, _duration).SetLoops(1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }
    }
}