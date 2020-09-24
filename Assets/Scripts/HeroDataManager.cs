using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class HeroDataManager : MonoBehaviour
{
    
    public static HeroDataManager Instance;
    [SerializeField]
    public Dictionary<long, Hero> heroes;
    //SO for creating new Heo objects with Instantiate
    public static readonly string SaveHeroesFolder="Characters";
    public static string path
    {
        get
        {
            return Application.persistentDataPath + "/" + SaveHeroesFolder;
        }
    }




    private void Awake()
    {
        //creates singletone and save folder
        init();

        Debug.Log("HERO SAVE MANAGER: loading all heroes data!");
        loadAllHeroesInstances();

    }



    private bool loadAllHeroesInstances()
    {
        DirectoryInfo dir = new DirectoryInfo(path);

        foreach (var fileInfo in dir.GetFileSystemInfos())
        {
            if (fileInfo.Extension == ".hr")
            {

                string jsonSave = DataController.tryReadSaveFromFile(fileInfo.Name, path);

                Hero hero=JsonUtility.FromJson<Hero>(jsonSave);
                print("loaded hero ->" + hero.getName());

                heroes.Add(hero.id, hero);
            }
        }
        return true;
    }

    //execute once
    private void init()
    {
        if (Instance == null) Instance = this;
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        heroes = new Dictionary<long, Hero>();
    }

    public bool saveHeroState(long _id)
    {
        Hero heroToSave = getHeroByID(_id);
        if (heroToSave == null)
        {
            Debug.LogError("HERO SAVE MANAGER: Hero not found");
            return false;
        }
        string jsonSave = JsonUtility.ToJson(heroToSave);

        if(!DataController.tryWriteSaveInFile(_id.ToString() + ".hr", path, jsonSave)) return false;

        Debug.Log("HERO SAVE MANAGER: hero with name " + heroToSave.getName() + " saved.");
        return true;
    }

    public bool loadHeroState(long _id)
    {

        Hero heroToLoad = getHeroByID(_id);
        if (heroToLoad == null)
        {
            Debug.LogError("HERO SAVE MANAGER: Hero not found");
            return false;
        }

        string jsonSave = DataController.tryReadSaveFromFile(_id.ToString() + ".hr", path);
        
        JsonUtility.FromJsonOverwrite(jsonSave, heroToLoad);
        Debug.Log("HERO SAVE MANAGER: hero with name " + heroToLoad.getName() + " loaded.");

        return true;
    }

    


     public Hero getHeroByID(long _id)
    {
        if (heroes.ContainsKey(_id)) return heroes[_id];
        Debug.Log("HERO SAVE MANAGER: hero with id " + _id + " not found");
        return null;
    }

    /// <summary>
    /// Add new hero object to system and try to save it in the files, it allows to save and load hero state in the future
    /// </summary>
    /// <returns></returns>
    public bool addNewHeroToData(Hero hero)
    {
        heroes.Add(hero.id, hero);
        return saveHeroState(hero.id);
    }

    public long getFreeID()
    {
        if (heroes.Count <= 0) return 1;
        long maxID = heroes.Keys.Max();
        return ++maxID;   
    }

    

}
