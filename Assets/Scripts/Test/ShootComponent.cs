using Unity.Netcode;
using UnityEngine;

public class ShootComponent : NetworkBehaviour
{
    [SerializeField] private GameObject _boolet;
    [SerializeField] private Transform _shootTransform;
    void Update()
    {
        if (IsOwner)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootServerRpc();
            }
        }
    }

    [ServerRpc]
    private void ShootServerRpc()
    {
        var go = Instantiate(_boolet, _shootTransform.position, _shootTransform.rotation);
        go.GetComponent<NetworkObject>().Spawn();
    }
}
