using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private List<Transform> _cameraPosition = null;
    [SerializeField] private int _poz = 0;
    [SerializeField] private float _speed = 2;
    private void LateUpdate()
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _cameraPosition[_poz].position, Time.deltaTime*_speed);
        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, _cameraPosition[_poz].rotation, Time.deltaTime*_speed);
    }
    
}
