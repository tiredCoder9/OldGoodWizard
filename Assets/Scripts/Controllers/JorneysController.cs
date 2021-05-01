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
    [ReadOnly] public Dictionary<Id, Jorney> jorneysComponents;
    private List<JorneyData> initializedJorneysLookup;

    [Header("Constansts")]
    public ConstantFloat tropeChance;
    public ConstantInteger diaryMaxCount;
    public ConstantInteger jorneyStepDelay;

    [SerializeField]
    private PlayerInventoryList inventory;

    private void Awake()
    {
        initializedJorneysLookup = new List<JorneyData>();
        jorneysObjects = new List<GameObject>();
        jorneysComponents = new Dictionary<Id, Jorney>();
    }


    private void Start()
    {
        initializeAll();

        //добавляем наблюдателя, которые будет следить за попытками пользователя создать путешествие
        EventSystem.Instance.AddEventListener<GUIEvent_JorneyStartEvent>(OnJorneyStart);
        EventSystem.Instance.AddEventListener<GUIEvent_finishJorney>(OnJorneyEnd);
    }

    //инициализация всех активных Jorney, которые были загружены
    private void initializeAll()
    {
        foreach (var jorney in JorneyDataManager.Instance.GetJorneys())
        { 
            initilize(jorney);
        }
    }



    private void initilize(JorneyData jorney)
    {
        GameObject _jorneyPatternObject = Instantiate(jorneyPrefab);

        Jorney _jorneyComponent = _jorneyPatternObject.GetComponent<Jorney>();
        jorneysComponents.Add(jorney.Id, _jorneyComponent);

        //получение ссылки на генератор
        _jorneyComponent.generator = _jorneyPatternObject.GetComponent<AdventureGenerator>();
        _jorneyComponent.values = jorney;

        jorneysObjects.Add(_jorneyPatternObject);
        initializedJorneysLookup.Add(jorney);    
    }


    private void deinitialize(JorneyData jorney)
    {
        
        //TODO: перенести обработку состояния героя в другое место
        if (jorney.CurrentState==JorneyData.JorneyState.endedFail)
        {
            if (jorney.Hero.isAlive())
            {
                jorney.Hero.State = Hero.HeroState.lost;
            }
            else
            {
                jorney.Hero.State = Hero.HeroState.dead;
            }
        }
        else
        {
            jorney.Hero.State = Hero.HeroState.tower;
        }


        //...здесь будет обработка инвентаря
        if (jorney.CurrentState == JorneyData.JorneyState.endedReturn) inventory.getValue().AddList(jorney.Inventory);

        jorney.Hero.save();
        TropeDataManager.Instance.deleteObject(jorney.CurrentTrope.Id);
        jorney.delete();
    }

    //при создении путешествия инициализируем его
    private void OnJorneyStart(GUIEvent_JorneyStartEvent startEvent)
    {
        if (!startEvent.heroID.IsInitialized && !startEvent.adventureModuleID.IsInitialized) return;

        if (!initializedJorneysLookup.Any(jorney => jorney.Hero.Id == startEvent.heroID))
        {
            Hero heroForJorney = HeroDataManager.Instance.getHeroByID(startEvent.heroID);
            AdventureModule module = AdventureModuleStore.Instance.getObject(startEvent.adventureModuleID);
            if (heroForJorney!=null && heroForJorney.State == Hero.HeroState.tower && module!=null)
            {
                heroForJorney.State = Hero.HeroState.adventure;
                Timer timer = new Timer(GameManager._GLOBAL_TIME_, jorneyStepDelay.Value);
                Diary diary = new Diary(diaryMaxCount.Value);
                JorneyData jorneyData = new JorneyData(startEvent.heroID, startEvent.adventureModuleID, 0, (int)tropeChance.Value, diary, timer);        
                JorneyDataManager.Instance.addNewJorneyData(jorneyData);


                initilize(jorneyData);
            }
        }
    }


    //завершение путешествия
    private void OnJorneyEnd(GUIEvent_finishJorney finishedJorneyEvent)
    {
        if (finishedJorneyEvent != null)
        {
            JorneyData finishedJorneyData = JorneyDataManager.Instance.getJorneyDataByID(finishedJorneyEvent.jorneyID);

            if(finishedJorneyData!=null && finishedJorneyData.Hero != null)
            {
                if (initializedJorneysLookup.Contains(finishedJorneyData) &&
                    (finishedJorneyData.CurrentState==JorneyData.JorneyState.endedFail || 
                    finishedJorneyData.CurrentState==JorneyData.JorneyState.endedReturn))
                {
                    deinitialize(finishedJorneyData);
                }
            }
        }
    }

}
