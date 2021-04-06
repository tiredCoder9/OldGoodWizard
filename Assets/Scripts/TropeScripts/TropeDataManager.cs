using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TropeDataManager : Singletone<TropeDataManager>, IDataManager
{

    private ContentLoader<TropeInstance> contentLoader;
    public List<TropeInstance> lists;

    private void LateUpdate()
    {
        UpdateData();
    }

    public void LoadData()
    {
        contentLoader = new ContentLoader<TropeInstance>(new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All });
        contentLoader.Initialize();
    }

    public void UpdateData()
    {
        if (contentLoader.hasDirties())
        {
            contentLoader.saveDirties();
        }
    }

    public TropeInstance getObject(Id id)
    {
        return contentLoader.getObject(id);
    }


    public void addObject(TropeInstance trope)
    {
        if (contentLoader.containsObject(trope.Id))
        {
            contentLoader.updateObject(trope);
        }
        else
        {
            contentLoader.AddObject(trope);
        }

    }

    public void deleteObject(Id id)
    {
        contentLoader.deleteObject(id);
    }


}
