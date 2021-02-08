using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PersistentVariableData<T> : BasePersistentVariableData, Identifyable
{
    public T value;

    public PersistentVariableData(T value, string name){
        this.value = value;
        this.name = name;
    }


    [JsonIgnore] public Id Id
    {
        get
        {
            return new Id(name);
        }
    }




}
