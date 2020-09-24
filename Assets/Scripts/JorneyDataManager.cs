using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class JorneyDataManager : MonoBehaviour
{
    public static List<JorneyData> jorneysDataList;
    public static string jorneysFolderName = "Jorneys";
    public JorneyData testJorney;



    public static string jorneysFolderPath
    {
        get
        {
            return Application.persistentDataPath + "/" + jorneysFolderName;
        }
    }



    /// <summary>
    /// Return list of loaded jorneys (even empty)
    /// </summary>
    /// <returns></returns>
    public static List<JorneyData> GetJorneys()
    {
       
        if (jorneysDataList == null) loadAllJorneysData();
        return jorneysDataList;
    }

    private static void loadAllJorneysData()
    {
        Debug.Log("JORNEYS DATA MANAGER: jorneys data loading...");
        jorneysDataList = new List<JorneyData>();

        if (!Directory.Exists(jorneysFolderPath)) Directory.CreateDirectory(jorneysFolderPath);

        DirectoryInfo dir = new DirectoryInfo(jorneysFolderPath);
        foreach(var file in dir.GetFileSystemInfos())
        {
            if (file.Extension == ".jor")
            {
                jorneysDataList.Add(loadJorneyData(file.Name));
            }
        }
        
    }


    private static JorneyData loadJorneyData(string fileName)
    {
        JorneyData _jorneyData = new JorneyData();
        string _JsonSave = DataController.tryReadSaveFromFile(fileName, jorneysFolderPath);
        _jorneyData = JsonUtility.FromJson<JorneyData>(_JsonSave);
        Debug.Log("JORNEYS DATA MANAGER: data of jorney (id):" + _jorneyData.id + " loaded!");
        return _jorneyData;
    }


    public static bool saveJorneyData(string jorneyID)
    {
        JorneyData jorneyData = getJorneyDataByID(jorneyID);
        if (jorneyData == null)
        {
            Debug.Log("JORNEY DATA MANAGER: jorney not found. Use addNewJorney() to add new object.");
        }
        string jsonSave = JsonUtility.ToJson(jorneyData);
        Debug.Log("JORNEY DATA MANAGER: jorney with id " + jorneyID + " saved.");
        return DataController.tryWriteSaveInFile(jorneyID + ".jor", jorneysFolderPath, jsonSave);
    }

    public static JorneyData getJorneyDataByID(string _jorneyID)
    {
        return jorneysDataList.First(jorn => jorn.id == _jorneyID);
    }

    /// <summary>
    /// Add new Jorney Data object to the system and save it.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public static bool addNewJorneyData(JorneyData _jorneyToAdd)
    {
        jorneysDataList.Add(_jorneyToAdd);
        return saveJorneyData(_jorneyToAdd.id);
    }



}
