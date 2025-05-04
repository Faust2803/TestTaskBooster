using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUi : NetworkBehaviour
{
    [SerializeField] private Button  _hostButton;
    [SerializeField] private Button  _clientButton;
    [SerializeField] private TextMeshProUGUI  _connectionCounterText;

    private NetworkVariable<int> _connectionCounter = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        
        _clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }

    // Update is called once per frame
    void Update()
    {
        _connectionCounterText.text ="Players: "+_connectionCounter.Value.ToString();
        if (IsServer)
        {
            _connectionCounter.Value = NetworkManager.Singleton.ConnectedClients.Count;
        }
        
    }
}
