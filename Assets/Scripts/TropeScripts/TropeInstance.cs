using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TropeInstance : Identifyable, ISaveable
{

    [JsonProperty] protected Id id;
    [JsonProperty] private bool _isUsed = false;

    [JsonIgnore] public Id Id { get { return id; } }
    [JsonIgnore] private bool dirtyFlag = false;
    [JsonIgnore] public bool IsUsed { get { return _isUsed; } }
   
    public virtual void begin(JorneyData jorney) { }



    public virtual bool ended(JorneyData jorney) { return true; }


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

}

[System.Serializable]
public abstract class TropeBehaviour
{
    //набор методов определяется только внешней реализацией для конкретного интерфейса события, данный тип необходим, чтобы закрепить разделение события на данные и поведение
}







