using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMessage
{
    public string Header;
    public string Message;

    public GameMessage(string Header, string Message)
    {
        this.Header = Header;
        this.Message = Message;
    }
}
