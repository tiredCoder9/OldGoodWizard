using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class TropeInstance : Identifyable
{

    [JsonProperty] protected Id id;
    [JsonProperty] private bool _isUsed = false;

    [JsonIgnore] public Id Id { get { return id; } }
    [JsonIgnore] public bool IsUsed { get { return _isUsed; } }

    public virtual void begin(JorneyData jorney) { }
    public virtual bool ended(JorneyData jorney) { return true; }
    public virtual void serialize() { }
    public virtual void deserialize() { }
}
[System.Serializable]
public abstract class TropeData 
{
    public abstract void serialize();
    public abstract void deserialize();
}

[System.Serializable]
public abstract class TropeBehaviour
{
    //набор методов определяется только внешней реализацией для конкретного интерфейса события, данный тип необходим, чтобы закрепить разделение события на данные и поведение
}







