using System.Collections.Generic;
using Tcl;
using UnityEngine;
using UnityEngine.UI;

public class ChatLog : MonoBehaviour
{
    [SerializeField] private GameObject chatLogEntryPrefab;
    [SerializeField] private RectTransform chatLogContainer;

    private List<ChatLogEntry> chatLogEntries = new();
    private ScrollRect scrollRect;

    private void Awake()
    {
        scrollRect = chatLogContainer.GetComponentInParent<ScrollRect>();
    }

    private void Start()
    {
        // Clear any chat log objects from edit mode
        foreach (Transform child in chatLogContainer)
            Destroy(child.gameObject);
    }

    public void OnChatMessageReceived(StreamEvent_Anywhere_ChatMessage chatEvent, Viewer viewer)
    {
        // Create new entry
        ChatLogEntry newEntry = Instantiate(chatLogEntryPrefab, chatLogContainer).GetComponent<ChatLogEntry>();
        newEntry.Populate(viewer.UserName + ":", viewer.Color, chatEvent.Text);
        chatLogEntries.Add(newEntry);

        // Scroll to bottom of chat log to see latest entry
        Canvas.ForceUpdateCanvases();
        scrollRect.StopMovement();
        scrollRect.verticalNormalizedPosition = 0;
    }
}
