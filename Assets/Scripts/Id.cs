using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

//КОНТРАКТ: Id пустой строки будет соответствовать null

[System.Serializable]
public struct Id 
{
    [SerializeField][Newtonsoft.Json.JsonProperty] private string value;
    public Id ( string _value)
    {
        value = _value;
    }

    public string get()
    {
        return value;
    }

    public void set(string _value)
    {
        value = _value;
    }
}
