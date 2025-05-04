using UnityEngine;
using System.Collections;

namespace Game
{
    public class Canon :MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Transform _startPoz ;
        [SerializeField] private Transform _finishPoz ;
        [SerializeField] private float _duration = 0.3F;
        [SerializeField] private GameObject _canonModel;
        [SerializeField] private Transform _firePoint;
        

        private bool _movingToTarget = true;
        


        public void Fire()
        {
            Debug.Log("Fire");
            _particle.Play();
            
            StartCoroutine(Move());
        }
        
        private IEnumerator Move()
        {
            var move = true;
            while (move)
            {
                _canonModel.transform.position = Vector3.MoveTowards(_canonModel.transform.position,
                    _finishPoz.position,
                    _duration * Time.deltaTime
                    );
                if (Vector3.Distance(_canonModel.transform.position, _finishPoz.position) < 0.01f)
                {
                    move = false;
                }
                yield return null;
            }
            move = true;
            while (move)
            {
                _canonModel.transform.position = Vector3.MoveTowards(_canonModel.transform.position,
                    _startPoz.position,
                    _duration * Time.deltaTime
                );
                if (Vector3.Distance(_canonModel.transform.position, _startPoz.position) < 0.01f)
                {
                    move = false;
                }
                yield return null;
            }
        }
    }
}