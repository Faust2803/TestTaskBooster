using System;
using System.Collections.Generic;
using Game;
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
    [Space]
    [SerializeField] private CameraPosition _camera;
    [Space]
    [SerializeField] private int _bulletCounter = 300;
    [SerializeField] private int _knipelCounter = 300;
    [SerializeField] private int _buckshotCounter = 300;
    [SerializeField] private int _grenadeCounter = 300;
    
    [SerializeField] private List<Canon> _leftCanons = new List<Canon>();
    [SerializeField] private List<Canon> _rightCanons = new List<Canon>();

    public event Action<FireType, int, List<Canon>> OnAmmoChanged; 
    
    private float currentTurnSpeed = 0f;
    private float currentSpeed = 0f;
    private float velocity = 0f;

    private SpeedType _speedType;
    private TernType _ternType;
    private FireTernType _fireTernType;
    private FireType _fireType;

    private GameObject _compass;

    void Update()
    {
        //var moveZ = Input.GetAxis("Vertical");
        var moveZ = (float)_speedType;
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
        
        //var moveX = Input.GetAxis("Horizontal");
        var moveX = (float)_ternType;
        if (moveX != 0)
        {
            currentTurnSpeed = Mathf.MoveTowards(currentTurnSpeed, moveX * _maxTurnSpeed, _accelerationTern * Time.deltaTime);
        }
        else
        {
            currentTurnSpeed = Mathf.MoveTowards(currentTurnSpeed, 0f, _decelerationTern * Time.deltaTime);
        }
        if (_compass)
        {
            _compass.transform.Rotate(Vector3.forward, currentTurnSpeed * Time.deltaTime);
        }
        transform.Rotate(Vector3.up, currentTurnSpeed * Time.deltaTime);
    }
    
    public void StartGame()
    {
        OnAmmoChanged.Invoke(FireType.Bullet, _bulletCounter, null);
        OnAmmoChanged.Invoke(FireType.Knipel, _knipelCounter, null);
        OnAmmoChanged.Invoke(FireType.Buckshot, _buckshotCounter, null);
        OnAmmoChanged.Invoke(FireType.Grenade, _grenadeCounter, null);
    }

    public void SetCameraPosition(CameraPositionType position)
    {
        _camera.SetPosition(position);
    }
    
    public void SetSpeed(SpeedType type)
    {
        _speedType = type;
    }
    
    public void SetTern(TernType type)
    {
        _ternType = type;
    }
    
    public void SetFire(FireTernType ternType)
    {
        //Debug.Log($"Fire type: {ternType}");
        _fireTernType = ternType;
        List<Canon> canons;
        switch (ternType)
        {
            case FireTernType.Left:
                canons = _leftCanons;
                break;
            case FireTernType.Right:
                canons = _rightCanons;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ternType), ternType, null);
        }
       
        var count = 0;
        switch (_fireType)
        {
            case FireType.Bullet:
                _bulletCounter -= canons.Count;
                count = _bulletCounter;
                break;
            case FireType.Knipel:
                _knipelCounter -= canons.Count;
                count = _knipelCounter;
                break;
            case FireType.Buckshot:
                _buckshotCounter -= canons.Count;
                count = _buckshotCounter;
                break;
            case FireType.Grenade:
                _grenadeCounter -= canons.Count;
                count = _grenadeCounter;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        OnAmmoChanged.Invoke(_fireType, count, canons);
        foreach (var t in canons)
        {
            t.Fire();
        }
    }

    public void SetCompass(GameObject compass)
    {
        _compass = compass;
    }
    
    public void OnFireTypeChanged(FireType type)
    {
        _fireType = type;
    }
}

public enum SpeedType
{
    Stop,
    Half,
    Full
}

public enum TernType
{
    Left = -1,
    None = 0,
    Right = 1
}

public enum FireTernType
{
    Left,
    Right
}

public enum FireType
{
    Bullet,
    Knipel,
    Buckshot,
    Grenade
}
