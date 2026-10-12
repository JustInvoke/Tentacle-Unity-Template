using TMPro;
using UnityEngine;

public class ChatLogEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI messageText;

    public void Populate(string name, Color nameColor, string message)
    {
        nameText.SetText(name);
        nameText.color = nameColor;
        messageText.SetText(message);
    }
}
