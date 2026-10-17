using Tcl;
using TMPro;
using UnityEngine;

public class TentacleStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;

    private void Update()
    {
        // Change color based on connection status
        switch (Tentacle.Client.ConnectionStatus)
        {
            case ConnectionStatus.Connected:
                statusText.color = Color.green;
                break;
            case ConnectionStatus.Connecting:
            case ConnectionStatus.Reconnecting:
                statusText.color = Color.yellow;
                break;
            case ConnectionStatus.Disconnected:
                statusText.color = Color.red;
                break;
            default:
                statusText.color = Color.white;
                break;
        }

        statusText.SetText(Tentacle.Client.ConnectionStatus.ToString());
    }
}
