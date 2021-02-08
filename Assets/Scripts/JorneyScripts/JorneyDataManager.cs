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

    public void LoadData()
    {
        contentLoader.Initialize();
    }

    public List<JorneyData> GetJorneys()
    {
       
        return contentLoader.getObjectsList();
    }

    private void loadJorneyData(Id id)
    {
        //TODO: реализовать
    }


    public void saveJorneyData(Id jorneyID)
    {
        contentLoader.saveObject(jorneyID);
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
        contentLoader.saveObject(_jorneyToAdd.Id);
    }

    public void deleteObject(Id id)
    {
        if (contentLoader.containsObject(id))
        {
            contentLoader.deleteObject(id);
        }
    }



}
