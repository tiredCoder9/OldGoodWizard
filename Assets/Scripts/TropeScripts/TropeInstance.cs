using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TropeInstance : Identifyable, ISaveable
{
    [JsonProperty] protected Id id;

    [JsonIgnore] public Id Id { get { return id; } }
    [JsonIgnore] private bool dirtyFlag = false;

    public virtual void begin(JorneyData jorney) { }

    public virtual bool ended(JorneyData jorney) { return true; }

    public virtual bool IsEnded { get { return true; } }

    public virtual void InitializeBehaviours(JorneyData jorney) { }

    public void delete()
    {
        TropeDataManager.Instance.deleteObject(id);
    }

    public void save()
    {
        setDirty(true);
    }

    public bool getDirty()
    {
        return dirtyFlag;
    }

    public void setDirty(bool value)
    {
        dirtyFlag = value;
    }



}


[System.Serializable]
public abstract class TropeData 
{
    [JsonProperty] protected bool isEnded = false;
    [JsonIgnore] public bool IsEnded { get { return isEnded; } set { isEnded = value; } }
}

[System.Serializable]
public abstract class TropeBehaviour
{
    //набор методов определяется только внешней реализацией для конкретного интерфейса события, данный тип необходим, чтобы закрепить разделение события на данные и поведение
}







