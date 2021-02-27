using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

//КОНТРАКТ: Id пустой строки будет соответствовать null

[System.Serializable]
public struct Id
{

    [SerializeField] [Newtonsoft.Json.JsonProperty] private string value;
    [Newtonsoft.Json.JsonIgnore] public bool IsInitialized { get { return value != null && value != string.Empty; } }

    public Id(string value)
    {
        this.value = value;
    }

    public string get()
    {
        return value;
    }



    public static bool operator ==(Id a, Id b){
        return a.value == b.value;
    }


    public static bool operator !=(Id a, Id b)
    {
        return a.value != b.value;
    }

    public static Id empty
    {
        get { return new Id();  }
    }
}

