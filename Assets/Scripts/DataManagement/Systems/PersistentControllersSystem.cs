using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentControllersSystem : Singletone<PersistentControllersSystem>, IDataManager
{
    private ContentLoader<PersistentControllerData> contentLoader;

    [SerializeField] private List<PersistentController> persistentControllers;

    private PersistentControllersSystem()
    {
        contentLoader = new ContentLoader<PersistentControllerData>(new Newtonsoft.Json.JsonSerializerSettings { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All });
    }

    public void LoadData()
    {
        contentLoader.Initialize();
        AssignControllers();
    }

    public void UpdateData()
    {
        if (contentLoader.hasDirties())
        {
            contentLoader.saveDirties();
        }
    }


    private void AssignControllers()
    {
        foreach(var controller in persistentControllers)
        {
            if (controller.GetControllerData() == null) continue;

            var tempId = controller.GetControllerData().Id;
            if (contentLoader.containsObject(tempId))
            {
                controller.SetControllerData(contentLoader.getObject(tempId));
            }
            else
            {
                controller.CreateControllerData();
                contentLoader.AddObject(controller.GetControllerData());
            }
        }
    }


    public PersistentControllerData getObject(Id id)
    {
        if (contentLoader.containsObject(id))
        {
            return contentLoader.getObject(id);
        }
        return null;
    }


    public void deleteObject(Id id)
    {
        if (contentLoader.containsObject(id))
        {
            contentLoader.deleteObject(id);
        }
    }

    public bool Constains(Id id)
    {
        return contentLoader.containsObject(id);
    }


}
