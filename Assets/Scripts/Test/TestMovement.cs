using System;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;


public class TestMovement : NetworkBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;
    
    [SerializeField] private Animator _animator;
    
    [SerializeField] private float _positionRange = 3F;

    public override void OnNetworkSpawn()
    {
        transform.position = new Vector3(Random.Range(-_positionRange, _positionRange), transform.position.y, Random.Range(-_positionRange, _positionRange));
        transform.rotation = new Quaternion(0, 180, 0,0);
    }
    void Update()
    {
        if (IsOwner)
        {
            var move = 0F;
            move = Input.GetAxis("Vertical"); // Использует W/S или стрелки
            //Debug.Log(move);
            transform.position += transform.forward * move * _speed * Time.deltaTime;
    
            var turn = Input.GetAxis("Horizontal") * _turnSpeed;
            transform.Rotate(0, turn, 0);
            
            _animator.SetFloat("speed", Math.Abs(move));
        }
        
    }
}
