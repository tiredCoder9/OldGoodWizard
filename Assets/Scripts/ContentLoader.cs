using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GlobalContentLoader<T> where T: Saveable
{
    private Dictionary<Id, T> objects;
    private bool IsInitialized = false;
    private FileNameFormat fileFormat;

    private string path;

    public GlobalContentLoader()
    {
        objects = new Dictionary<Id, T>();
        fileFormat = new FileNameFormat("dt_", string.Empty, typeof(T).Name);
    }

    public GlobalContentLoader(FileNameFormat _fileFormat)
    {

        objects = new Dictionary<Id, T>();
        fileFormat = _fileFormat;
    }


    public void Initialize()
    {
        if (!IsInitialized)
        {
            path = Application.persistentDataPath + "/" + typeof(T).Name + "s";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            
            T[] loadedObjects = JsonTool.tryLoadDataByType<T>(path, fileFormat);

            for (int i = 0; i < loadedObjects.Length; i++)
            {
                objects.Add(loadedObjects[i].testID, loadedObjects[i]);
            }

            Debug.Log("Content Loader of type: " + typeof(T) + " load " + objects.Count + " objects!");

            IsInitialized = true;
        }
        
    }

    public T getObject(Id id)
    {
        if(objects.ContainsKey(id)) return objects[id];
        return null;
    }

    public void AddObject(T obj)
    {
        objects.Add(obj.testID ,obj);
    }

    public void saveObject(Id id)
    {
        if (objects.ContainsKey(id))
        {
            JsonTool.save<T>(objects[id], id.get(), path, fileFormat);
        }
    }

    public List<T> getObjectsList()
    {
        return objects.Values.ToList();
    }



}
