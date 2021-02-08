using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageBox : Singletone<MessageBox>
{
    
    public TextMeshProUGUI header;
    public TextMeshProUGUI text;
    public GameObject parentCanvas;

    private Queue<GameMessage> messages;
    private bool IsOpened;

    public void DeployMessage(GameMessage message)
    {
        if (messages == null) { messages = new Queue<GameMessage>(); }
        if (message != null)
        {
            messages.Enqueue(message);
        }

        if (!IsOpened)
        {
            Open(messages.Dequeue());
        }
    }

    private void Open(GameMessage message)
    {
        header.text = message.Header;
        text.text = message.Message;

        parentCanvas.SetActive(true);
        IsOpened = true;
    }

    public void OnBoxHide()
    {
        if (messages.Count > 0)
        {
            Open(messages.Dequeue());
        }
        else
        {
            IsOpened = false;
            parentCanvas.SetActive(false);
        }
    }


    
}
