using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataController
{


  

    public static bool tryWriteSaveInFile(string fileName, string path,string saveText)
    {
        if (!File.Exists(path + "/" + fileName))
        {
            Debug.LogWarning("HERO SAVE MANAGER: JSON save file not found. New save file created ->" + fileName);
        }

        File.WriteAllText(path + "/" + fileName, saveText);
        return true;
    }


    public static string tryReadSaveFromFile(string fileName, string path)
    {
        try
        {
            return File.ReadAllText(path + "/" + fileName);
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("DATA CONTROLLER: JSON save file not found. Load had been stopped ->" + fileName);
            return null;
        }
    }
}
