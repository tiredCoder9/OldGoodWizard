using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Reflection;
using System;

public class JorneysController : MonoBehaviour
{
    public GameObject jorneyPrefab;
    [ReadOnly] public List<GameObject> jorneysObjects;
    [ReadOnly] public static List<Jorney> jorneysComponents;
    //инициализация всех активных Jorney, которые удастся найти в памяти.
    private void Awake()
    {
        jorneysObjects = new List<GameObject>();
        jorneysComponents = new List<Jorney>();
        jorneysComponents.DefaultIfEmpty(null);
    }


    private void Start()
    {
        initializeAll();
    }


    void initializeAll()
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
        return jorneysComponents.FirstOrDefault(jorney => jorney.values.Id.get() == id.get());
    }

}
