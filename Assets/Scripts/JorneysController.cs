using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class JorneysController : MonoBehaviour
{
    public GameObject jorneyPrefab;
    [ReadOnly] public List<GameObject> jorneysObjects;
    [ReadOnly] public static List<Jorney> jorneysComponents;
    //инициализация всех активных Jorney, которые удастся найти в памяти.
    private void Awake()
    {
        CreateTestingJorney();

        jorneysObjects = new List<GameObject>();
        jorneysComponents = new List<Jorney>();
        jorneysComponents.DefaultIfEmpty(null);
        initializeJorneys();

    }


    void initializeJorneys()
    {
        foreach(var jorney in JorneyDataManager.GetJorneys())
        {
            GameObject _jorneyPatternObject = Instantiate(jorneyPrefab);

            Jorney _jorneyComponent =_jorneyPatternObject.GetComponent<Jorney>();
            jorneysComponents.Add(_jorneyComponent);

            jorney.adventureGenerator = _jorneyPatternObject.GetComponent<AdventureGenerator>();
            _jorneyComponent.values = jorney;

            jorneysObjects.Add(_jorneyPatternObject);
        }
    }


    public static Jorney getJorneyComponentById(string jorneyID)
    {
        return jorneysComponents.FirstOrDefault(jorney => jorney.values.id == jorneyID);
    }



    private void CreateTestingJorney()
    {
        if (PlayerPrefs.GetInt("firstRunning")==0)
        {
            Hero hero = new Hero();
            hero.id = 2;
            hero.setName("Adrian Fon Zigler");
            hero.setHealth(10000);
            hero.setPower(1);
            string heroSerialized = JsonUtility.ToJson(hero);
            if (!Directory.Exists(Application.persistentDataPath + "/" + HeroDataManager.SaveHeroesFolder))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + HeroDataManager.SaveHeroesFolder);
            }
            DataController.tryWriteSaveInFile(hero.id.ToString() + ".hr", Application.persistentDataPath + "/" + HeroDataManager.SaveHeroesFolder, heroSerialized);

            JorneyData jorney = new JorneyData();
            jorney.heroID = 2;
            jorney.hero = hero;
            jorney.lastTropeTime = 0;
            jorney.tempTime = 0;
            jorney.distance = 0;
            jorney.turnTimeDelay = 1;
            jorney.beginDate = 0;
            string jorneySerialized = JsonUtility.ToJson(jorney);
            if (!Directory.Exists(Application.persistentDataPath + "/" + JorneyDataManager.jorneysFolderName))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + JorneyDataManager.jorneysFolderName);
            }

            DataController.tryWriteSaveInFile(jorney.id + ".jor", Application.persistentDataPath + "/" + JorneyDataManager.jorneysFolderName, jorneySerialized);
            Debug.Log("JORNEY CONTROLLER: testing jorney created!");
            PlayerPrefs.SetInt("firstRunning", 1);
        }


    }
}
