using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class ContentLoader<T> where T: Identifyable, ISaveable
{
    protected Dictionary<Id, T> objects;
    protected bool IsInitialized = false;
    protected FileNameFormat fileFormat;
    protected string path;
    protected string fullpath;
    protected JsonSerializerSettings settings;
    protected ulong idIncrement=1;

    protected Dictionary<string, string> cashedObjects;

    protected bool globalDirtyFlag = false;


    public ContentLoader()
    {
        objects = new Dictionary<Id, T>();
        fileFormat = new FileNameFormat("dt_", string.Empty, typeof(T).Name);
        settings = new JsonSerializerSettings();
        cashedObjects = new Dictionary<string, string>();
    }

    public ContentLoader(FileNameFormat _fileFormat, JsonSerializerSettings _settings)
    {
        cashedObjects = new Dictionary<string, string>();
        objects = new Dictionary<Id, T>();
        fileFormat = _fileFormat;

        settings = _settings;
    }

    public virtual void Initialize()
    {
        if (!IsInitialized)
        {
            loadObjects();
        }
        
    }


    public void loadObjects()
    {
        path = Application.persistentDataPath;

        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        fullpath = path + "/" + typeof(T).Name + "Collection";

        string serializedCollection = FileSystemFacade.tryReadSaveFromFile(fullpath);

        if (serializedCollection != null)
        {
            cashedObjects = JsonConvert.DeserializeObject<Dictionary<string, string>>(serializedCollection, settings);

            foreach (var cashObject in cashedObjects)
            {
                T instance = JsonConvert.DeserializeObject<T>(cashObject.Value, settings);

                objects.Add(instance.Id, instance);

                ulong tempID = 0;
                if (ulong.TryParse(instance.Id.get(), out tempID))
                {
                    if (idIncrement < tempID) idIncrement = tempID;
                }
            }
        }

        Debug.Log("CONTENT LOADER: Objects of type "+ typeof(T).Name + " loaded - " + objects.Count);
        
    }



    public void saveDirties()
    {
        foreach (var obj in objects)
        {
            if (obj.Value.getDirty())
            {
                reserializeObject(obj.Value);
                obj.Value.setDirty(false);
            }
        }

        string serializedCollection = JsonConvert.SerializeObject(cashedObjects, settings);

        FileSystemFacade.tryWriteSaveInFile(fullpath, serializedCollection);
    }

    public bool hasDirties()
    {
        foreach(var obj in objects)
        {
            if (obj.Value.getDirty()) return true;
        }

        return globalDirtyFlag;
    }




    protected void reserializeObject(T obj)
    {
        if (cashedObjects.ContainsKey(obj.Id.get()))
        {
            string cashedObject = JsonConvert.SerializeObject(obj, settings);
            cashedObjects[obj.Id.get()] = cashedObject;
        }
    }





    //TODO переписать и протестировать, этот метод не должен брать на себя ответственность проверки
    public virtual T getObject(Id id)
    {
        if(objects.ContainsKey(id)) return objects[id];
        return default;
    }

    public virtual void AddObject(T obj)
    {
        objects.Add(obj.Id ,obj);
        AddObjectCash(obj);
        obj.setDirty(true);
    }

    protected virtual void AddObjectCash(T obj)
    {
        string cashedObject = JsonConvert.SerializeObject(obj, settings);
        cashedObjects.Add(obj.Id.get(), cashedObject);
    }


    public virtual List<T> getObjectsList()
    {
        return objects.Values.ToList();
    }

    public virtual void updateObject(T obj)
    {
        if (objects.ContainsKey(obj.Id))
        {
            objects[obj.Id] = obj;
            reserializeObject(obj);
            obj.setDirty(true);
        }
    }


    public virtual bool containsObject(Id id)
    {
        return objects.ContainsKey(id);
    }

    public virtual void deleteObject(Id id)
    {
        if (objects.ContainsKey(id))
        {
            objects.Remove(id);
            cashedObjects.Remove(id.get());
            globalDirtyFlag = true;
        }
    }

    public virtual List<Id> getKeys()
    {
        return objects.Keys.ToList();
    }



    public virtual Id generateUniqueID()
    {
        ++idIncrement;
        return new Id(idIncrement.ToString());
    }


}
