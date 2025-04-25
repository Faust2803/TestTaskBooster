using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private FireType _type;
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _damage = 1;
        [SerializeField] private float _lifeTime = 5;
        
        
    }
}