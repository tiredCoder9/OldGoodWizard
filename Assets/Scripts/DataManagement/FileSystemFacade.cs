using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class FileSystemFacade
{
    public static bool tryWriteSaveInFile(string fileName, string path,string saveText)
    {
        if (!File.Exists(path + "/" + fileName))
        {
            Debug.LogWarning("DATA CONTROLLER: JSON save file not found. New save file created ->" + fileName);
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
            Debug.LogError("DATA CONTROLLER: JSON save file not found. Load was canceled ->" + fileName);
            return null;
        }
    }



    public static string[] tryReadFilesByFormat(string path, FileNameFormat format)
    {
        List<string> data = new List<string>();
        try
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles())
            {
                if (format.IsFormatted(file.Name))
                {
                    data.Add(File.ReadAllText(path + "/" + file.Name));
                }
            }
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.LogError("DATA CONTROLLER: directory not found -> "+path);
        }

        return data.ToArray();
    }



    public static void tryDeleteFile(string path, string name)
    {
        try
        {
            File.Delete(path + "/" + name);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.LogError(e.Message);
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError(e.Message);
        }
        catch(IOException e)
        {
            Debug.LogError(e.Message);
        }
    }


    public static int countLinesNumber(string path, string filename)
    {
        var lineCount = 0;
        using (var reader = File.OpenText(path+"/"+filename))
        {
            while (reader.ReadLine() != null)
            {
                lineCount++;
            }
        }

        return lineCount;
    }


    public static string tryReadLine(string path, string filename, int line)
    {
        using (var sr = new StreamReader(path+"/"+filename))
        {
            for (int i = 1; i < line; i++)
                sr.ReadLine();
            return sr.ReadLine();
        }
    }
}
