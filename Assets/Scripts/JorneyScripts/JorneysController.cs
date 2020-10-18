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

        //TODO: перенести
        HeroDataManager.Instance.LoadData();
        JorneyDataManager.Instance.LoadData();


        jorneysObjects = new List<GameObject>();
        jorneysComponents = new List<Jorney>();
        jorneysComponents.DefaultIfEmpty(null);
        initializeJorneys();

    }


    void initializeJorneys()
    {
        

        foreach (var jorney in JorneyDataManager.Instance.GetJorneys())
        { 
            initilize(jorney);
        }
    }



    public void initilize(JorneyData jorney)
    {
        GameObject _jorneyPatternObject = Instantiate(jorneyPrefab);

        Jorney _jorneyComponent = _jorneyPatternObject.GetComponent<Jorney>();
        jorneysComponents.Add(_jorneyComponent);

        //получение ссылки на генератор
        _jorneyComponent.generator = _jorneyPatternObject.GetComponent<AdventureGenerator>();
        _jorneyComponent.values = jorney;

        jorneysObjects.Add(_jorneyPatternObject);
    }

    public static Jorney getJorneyComponentById(Id id)
    {
        return jorneysComponents.FirstOrDefault(jorney => jorney.values.testID.get() == id.get());
    }


    //TODO: ВРЕМЕННЫЙ КОД
    private void CreateTestingJorney()
    {
        if (PlayerPrefs.GetInt("firstRunning")==0)
        {
            FileNameFormat format = new FileNameFormat("dt_", string.Empty);

            Id heroID = new Id(2.ToString());

            Hero _hero = new Hero
            {
                testID = heroID,
            };
            _hero.setName("Adrian Fon Zigler");
            _hero.setHealth(10000);
            _hero.setPower(1);
            string heroSerialized = JsonUtility.ToJson(_hero);
            if (!Directory.Exists(Application.persistentDataPath + "/" + typeof(Hero).Name + "s"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + typeof(Hero).Name + "s");
            }

            Id testHeroID = new Id("jorney" + 2);

            JorneyData jorney = new JorneyData(testHeroID);
      
            string jorneySerialized = JsonUtility.ToJson(jorney);
            if (!Directory.Exists(Application.persistentDataPath + "/" + typeof(JorneyData).Name + "s"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + "JorneyDatas");
            }

            JsonTool.save<JorneyData>(jorney, jorney.testID.get(), Application.persistentDataPath + "/" + typeof(JorneyData).Name + "s", format);
            Debug.Log("JORNEY CONTROLLER: testing jorney created!");
            PlayerPrefs.SetInt("firstRunning", 1);
        }


    }
}
