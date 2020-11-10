﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TropeDataManager : Singletone<TropeDataManager>, IDataManager
{

    private FileNameFormat format;
    private ContentLoader<TropeInstance> contentLoader;
    public List<TropeInstance> lists; 

    public void LoadData()
    {
        format = new FileNameFormat("dt_", string.Empty, "trope");
        contentLoader = new ContentLoader<TropeInstance>(format, new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All });
        contentLoader.Initialize();
    }


    public void saveObject(Id id)
    {
        contentLoader.saveObject(id);
    }


    public TropeInstance getObject(Id id)
    {
        return contentLoader.getObject(id);
    }


    public void addObject(TropeInstance trope)
    {
        if (contentLoader.containsObjct(trope.Id))
        {
            contentLoader.updateObject(trope);
            contentLoader.saveObject(trope.Id);
        }
        else
        {
            contentLoader.AddObject(trope);
            contentLoader.saveObject(trope.Id);
        }

    }

    public void deleteObject(Id id)
    {
        contentLoader.deleteObject(id);
    }

    
}
