using TMPro;
using UnityEngine;

public class ChatLogEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI messageText;

    // Populates the chat log entry with the given name, name color, and message
    public void Populate(string name, Color nameColor, string message)
    {
        nameText.SetText(name);
        nameText.color = nameColor;
        messageText.SetText(message);
    }
}
