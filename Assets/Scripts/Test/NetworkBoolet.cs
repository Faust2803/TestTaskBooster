using System.Collections;
using Unity.Netcode;
using UnityEngine;


public class NetworkBoolet : NetworkBehaviour
{
    [SerializeField] private float _speed;

    private void Awake()
    {
        StartCoroutine(DestroyDelay());
    }
    
    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(5f);
        ShootServerRpc();
    }


    void FixedUpdate()
    {
        transform.position += transform.forward * _speed * Time.fixedDeltaTime;
    }
    
    
    [ServerRpc]
    private void ShootServerRpc()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShootServerRpc();
        }
        
    }
}
