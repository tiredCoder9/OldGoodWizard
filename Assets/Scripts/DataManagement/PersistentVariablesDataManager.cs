using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class PersistentVariablesDataManager : Singletone<PersistentVariablesDataManager>, IDataManager
{
    public BasePersistentVariable[] persistentVariables;
    public Dictionary<string, BasePersistentVariable> variablesLookup;

    public List<BasePersistentVariableData> variablesData;


    public string variables_collection_filename="varcollection.dat";
    public string collection_path="/vars/";
    public string[] serializedData;

    private string fullpath;
    private JsonSerializerSettings serializer;

    private void LateUpdate()
    {
        UpdateData();
    }

    public void LoadData()
    {
        print(Application.persistentDataPath + collection_path);
        if (Directory.Exists(Application.persistentDataPath + collection_path)) Directory.CreateDirectory(Application.persistentDataPath + collection_path);
        fullpath = Application.persistentDataPath + collection_path + variables_collection_filename;
        serializer = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        loadAll();
    }

    public void UpdateData()
    {
        if (checkDirtyFlags())
        {
            saveAll();
        }
    }



    private bool checkDirtyFlags()
    {
        for(int i=0; i<persistentVariables.Length; i++)
        {
            if (persistentVariables[i].IsDirty) return true;
        }
        return false;
    }



    void loadAll()
    {

        variablesLookup = createVariablesLookup(persistentVariables);

        string serialized_collection = FileSystemFacade.tryReadSaveFromFile(fullpath);

        if (serialized_collection != null)
        {
            variablesData = JsonConvert.DeserializeObject<List<BasePersistentVariableData>>(serialized_collection, serializer);
            assignAll(variablesLookup, variablesData);
        }
    }


    private void saveAll()
    {


        if (!Directory.Exists(Application.persistentDataPath + collection_path)) Directory.CreateDirectory(Application.persistentDataPath + collection_path);

        variablesData = new List<BasePersistentVariableData>();
        foreach (var variable in persistentVariables)
        {
            var data = variable.getVariableData();
            variablesData.Add(data);
        }

        string serializedData = JsonConvert.SerializeObject(variablesData, serializer);
        FileSystemFacade.tryWriteSaveInFile(fullpath, serializedData);
    }


    Dictionary<string, BasePersistentVariable> createVariablesLookup(BasePersistentVariable[] variables)
    {
        Dictionary<string, BasePersistentVariable> dict = new Dictionary<string, BasePersistentVariable>();

        foreach (var varb in variables)
        {
            dict.Add(varb.name, varb);
        }

        return dict;
    }

    

    private void assignAll(Dictionary<string, BasePersistentVariable> _variablesLookup, List<BasePersistentVariableData> _variablesData)
    {
        foreach(var data in _variablesData)
        { 
            if (_variablesLookup.ContainsKey(data.name))
            {
                _variablesLookup[data.name].loadVariableData(data);
            }
        }
    }


    private void OnDestroy()
    {
        restoreDefaultsAll();
    }

    private void restoreDefaultsAll()
    {
        foreach (var variable in persistentVariables)
        {
            variable.restoreDefaultValue();
        }
    }


}
