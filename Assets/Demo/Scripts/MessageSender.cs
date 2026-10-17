using Tcl;
using TMPro;
using UnityEngine;

public class MessageSender : MonoBehaviour
{
    [SerializeField] private string placeholderTextConnected = "Enter message...";
    [SerializeField] private string placeholderTextDisconnected = "Sign in to send messages";

    private TMP_InputField _inputField;
    private Tentacle_Connections _connections;
    private PlatformConnectionOutcome _platformOutcome;
    private PlatformConnectionStatus _platformStatus;

    private void OnEnable()
    {
        _connections = Tentacle.Connections;
        _connections.OnConnectResult += OnConnectResult;
        _connections.OnConnectionChanged += OnConnectionChanged;
    }

    private void OnDisable()
    {
        _connections.OnConnectResult -= OnConnectResult;
        _connections.OnConnectionChanged -= OnConnectionChanged;
        _inputField.interactable = false;
    }

    private void OnConnectResult(PlatformConnectionResult result)
    {
        _platformOutcome = result.Outcome;
        UpdateInputInteractable();
    }

    private void OnConnectionChanged(PlatformConnection connection)
    {
        _platformStatus = connection.Status;
        UpdateInputInteractable();
    }

    private void UpdateInputInteractable()
    {
        // Enable input field only if connected and sign in outcome is success
        bool isConnected = _platformStatus == PlatformConnectionStatus.Connected;
        bool isOutcomeSuccess = _platformOutcome == PlatformConnectionOutcome.Connected;
        _inputField.interactable = isConnected && isOutcomeSuccess;

        // Change placeholder text based on connection status
        string placeHolderText = _inputField.interactable ? placeholderTextConnected : placeholderTextDisconnected;
        _inputField.placeholder.GetComponent<TextMeshProUGUI>().SetText(placeHolderText);
    }

    private void Awake()
    {
        // Find or create input field component
        _inputField = GetComponentInChildren<TMP_InputField>();
        if (_inputField == null)
            _inputField = gameObject.AddComponent<TMP_InputField>();

        // Subscribe to the input field's onEndEdit event to send chat messages when the user presses Enter
        _inputField.onEndEdit.AddListener(SendChatMessage);
    }

    // Called when the user presses Enter while typing in the input field
    public void SendChatMessage(string message)
    {
        Tentacle.SendChatMessage(message);

        // Clear input field without triggering onEndEdit event again
        _inputField.SetTextWithoutNotify(string.Empty);
    }
}
