using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public abstract class PersistentControllerData : Identifyable
{
    [JsonProperty] protected Id _id;
    [JsonIgnore] public Id Id { get { return _id ; } }


    public virtual void clear()
    {
        PersistentControllersSystem.Instance.deleteObject(_id);
    }

    public virtual void save()
    {
        PersistentControllersSystem.Instance.saveObject(_id);
    }
}
