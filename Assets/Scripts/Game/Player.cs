using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _accelerationTime = 0.5f;
    [SerializeField] private float _decelerationTime = 0.5f;
    [Space]
    [SerializeField] private float _maxTurnSpeed = 10;
    [SerializeField] private float _accelerationTern = 5; 
    [SerializeField] private float _decelerationTern = 5;

    private float currentTurnSpeed = 0f;
    private float currentSpeed = 0f;
    private float velocity = 0f;

    void Update()
    {
        var moveZ = Input.GetAxis("Vertical");
        var smoothTime = 0F;
        var targetSpeed =  0F;
        if (moveZ != 0)
        {
            if (moveZ > 0)
            {
                targetSpeed = _maxSpeed;
            }
            else
            {
                targetSpeed = _maxSpeed * -1;
            }
            
            smoothTime = _accelerationTime;
        }
        else
        {
            smoothTime = _decelerationTime;
            targetSpeed =  0f;
        }
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref velocity, smoothTime);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        
        var moveX = Input.GetAxis("Horizontal");
        if (moveX != 0)
        {
            currentTurnSpeed = Mathf.MoveTowards(currentTurnSpeed, moveX * _maxTurnSpeed, _accelerationTern * Time.deltaTime);
        }
        else
        {
            currentTurnSpeed = Mathf.MoveTowards(currentTurnSpeed, 0f, _decelerationTern * Time.deltaTime);
        }
        transform.Rotate(Vector3.up, currentTurnSpeed * Time.deltaTime);
    }

   
}
