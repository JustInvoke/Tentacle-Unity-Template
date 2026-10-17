using Tcl;
using TMPro;
using UnityEngine;

public class MessageSender : MonoBehaviour
{
    private TMP_InputField _inputField;

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
