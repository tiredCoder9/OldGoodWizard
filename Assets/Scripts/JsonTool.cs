using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class JsonTool
{
    

    public static T[]  tryLoadDataByType<T>(string path, FileNameFormat format)
    {
        List<T> objects = new List<T>();
        DirectoryInfo dir = new DirectoryInfo(path);

        foreach(var file in dir.GetFiles())
        {
            Debug.Log(file.Name);
            if (format.IsFormatted(file.Name))
            {
                string serializedObject = DataController.tryReadSaveFromFile(file.Name, path);
                T obj = JsonUtility.FromJson<T>(serializedObject);

                objects.Add(obj);
            }
        }

        return objects.ToArray();

    }




    public static void save<T>(T obj, string name, string path, FileNameFormat format)
    {
        string serializedObject = JsonUtility.ToJson(obj);
        string formattedName = format.formateName(name);

        DataController.tryWriteSaveInFile(formattedName, path, serializedObject);
    }

    public static void remove<T>(T obj)
    {
        //TODO: реализовать
    }

    public static void load<T>(string name)
    {
        //TODO: реализовать
    }


}




