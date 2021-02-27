using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class JorneyDataManager : Singletone<JorneyDataManager>, IDataManager
{

    public ContentLoader<JorneyData> contentLoader;


    private JorneyDataManager()
    {
        contentLoader = new ContentLoader<JorneyData>();
    }

    private void LateUpdate()
    {
        UpdateData();
    }

    public void LoadData()
    {
        contentLoader.Initialize();
    }

    public void UpdateData()
    {
        if (contentLoader.hasDirties())
        {
            contentLoader.saveDirties();
        }
    }

    public List<JorneyData> GetJorneys()
    {
        return contentLoader.getObjectsList();
    }


    public JorneyData getJorneyDataByID(Id id)
    {
        return contentLoader.getObject(id);
    }

    /// <summary>
    /// Add new Jorney Data object to the system and save it.
    /// </summary>
    public void addNewJorneyData(JorneyData _jorneyToAdd)
    {
        contentLoader.AddObject(_jorneyToAdd);
    }

    public void deleteObject(Id id)
    {
        if (contentLoader.containsObject(id))
        {
            contentLoader.deleteObject(id);
        }
    }



}
