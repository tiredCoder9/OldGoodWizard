using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class ContentLoader<T> where T: Identifyable
{
    protected Dictionary<Id, T> objects;
    protected bool IsInitialized = false;
    protected FileNameFormat fileFormat;
    protected string path;
    protected JsonSerializerSettings settings;
    protected ulong idIncrement=1;

    public ContentLoader()
    {
        objects = new Dictionary<Id, T>();
        fileFormat = new FileNameFormat("dt_", string.Empty, typeof(T).Name);
        settings = new JsonSerializerSettings();
    }

    public ContentLoader(FileNameFormat _fileFormat, JsonSerializerSettings _settings)
    {
        objects = new Dictionary<Id, T>();
        fileFormat = _fileFormat;

        settings = _settings;
    }


    public virtual void Initialize()
    {
        if (!IsInitialized)
        {
            path = Application.persistentDataPath + "/" + typeof(T).Name + "s";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            string[] serializedData = FileSystemFacade.tryReadFilesByFormat(path, fileFormat);

            foreach (string serializedObj in serializedData)
            {
                T instance = JsonConvert.DeserializeObject<T>(serializedObj, settings);
                
                objects.Add(instance.Id, instance);

                ulong tempID=0;
                if(ulong.TryParse(instance.Id.get(), out tempID))
                {
                    if (idIncrement < tempID) idIncrement = tempID;
                }

            }

            IsInitialized = true;
            Debug.Log("Content Loader of type: " + typeof(T).Name + " load " + objects.Count + " objects!");

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
    }

    public virtual void saveObject(Id id)
    {
        if (objects.ContainsKey(id))
        {
            string serializedObj = JsonConvert.SerializeObject(objects[id], settings);
            string name = fileFormat.formateName(id.get());

            FileSystemFacade.tryWriteSaveInFile(name, path, serializedObj);
        }
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
            FileSystemFacade.tryDeleteFile(path, fileFormat.formateName(id.get()));
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
