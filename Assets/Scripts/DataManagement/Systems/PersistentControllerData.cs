using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public abstract class PersistentControllerData : Identifyable, ISaveable
{
    [JsonProperty] protected Id _id;
    [JsonIgnore] public Id Id { get { return _id ; } }

    [JsonIgnore] private bool dirtyFlag = false;

    

    public void delete()
    {

    }

    public virtual void save()
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
