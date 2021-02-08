using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using Newtonsoft.Json;

[System.Serializable]
public class JorneyData : Identifyable, ISaveable
{
    //этот обьект содержит только данные, аккумулируя в себе всю информацию конкретного путешествия
    [JsonProperty] [SerializeField] private Id _id;                          //идентификатор
    [JsonProperty] [SerializeField] private Id heroID;                       //персонаж путешествия
    [JsonProperty] [SerializeField] private Id adventureModuleID;            //модуль ресурсов событий
    [JsonProperty] [SerializeField] private Id currentTropeID;               //текущее событие 
    [JsonProperty] [SerializeField] private float distance = 0;              //пройденное расстояние
    [JsonProperty] [SerializeField] private int tropeChance = 5;             //шанс появления события
    [JsonProperty] [SerializeField] private Timer timer;                     //отвечает за внутренее время путешествия
    [JsonProperty] [SerializeField] private List<Id> passedTropesID;         //очередь пройденных событий
    [JsonProperty] [SerializeField] private Diary diary;                     //лог текстовых сообщений событий
    [JsonProperty] [SerializeField] private MovingDirection currentDirection = MovingDirection.forward;
    [JsonProperty] [SerializeField] private JorneyState currentState = JorneyState.moving;

    [JsonIgnore] public Id Id { get { return _id; } }
    [JsonIgnore] public Hero Hero { get { return HeroDataManager.Instance.getHeroByID(heroID); } }
    [JsonIgnore] public AdventureModule MainModule { get { return AdventureModuleStore.Instance.getObject(adventureModuleID); } }
    [JsonIgnore] public TropeInstance CurrentTrope { get { return TropeDataManager.Instance.getObject(currentTropeID); } } 

    public enum JorneyState { moving, standingTrope, endedFail, endedReturn}          //состояние путешествия - передвижение/происходит событие
    public enum MovingDirection { forward = 1, backward = -1 }    //направление движения вперед/назад
    [JsonIgnore] public JorneyState CurrentState
    { get
        {
            return currentState;
        }
      set
        {
            JorneyState prevState = currentState;
            currentState = value;
            EventSystem.Instance.Raise(new Event_JorneyStateChanged(Id, prevState));
        }
    }
    [JsonIgnore] public MovingDirection CurrentDirection
    { get
        {
            return currentDirection;
        }
      set
        {
            MovingDirection prev = currentDirection;
            currentDirection = value;
            EventSystem.Instance.Raise(new Event_JorneyDirectionChanged(Id, prev));
        }
    }

    [JsonIgnore] public float Distance { get { return distance; } set
        {
            distance = value;
            if (distance < 0) distance = 0;
            EventSystem.Instance.Raise(new Event_JorneyDistanceChanged(Id, Distance));
        }
    }
    [JsonIgnore] public int TropeChance { get { return tropeChance; } set { tropeChance = value; } }
    [JsonIgnore] public Timer Timer { get { return timer; } }
    [JsonIgnore] public List<Id> PassedTropesID { get { return passedTropesID; } }
    [JsonIgnore] public Diary Diary { get { return diary; } }

    //Не открывай, убьет
    #region Constructors
    public JorneyData(JorneyData _jorney)
    {
        this._id = _jorney.Id;
        this.adventureModuleID = _jorney.adventureModuleID;
        this.currentTropeID = _jorney.currentTropeID;
        this.heroID = _jorney.heroID;
        this.Distance = _jorney.Distance;
        this.TropeChance = _jorney.TropeChance;
        this.timer = _jorney.Timer;
        this.diary = _jorney.Diary;
        this.CurrentState = _jorney.CurrentState;
        this.CurrentDirection = _jorney.CurrentDirection;
        this.passedTropesID = _jorney.PassedTropesID;
    }

    public JorneyData(Id _heroID, Id _adventureModuleID, float _distance, int _tropeChance)
    {
        heroID = _heroID;
        adventureModuleID = _adventureModuleID;
        Distance = _distance;
        TropeChance = _tropeChance;

        diary = new Diary();
        timer = new Timer();
        passedTropesID = new List<Id>();
        _id = new Id("jorney" + _heroID.get());
    }

    public JorneyData(Id _heroID, Id _adventureModuleID, float _distance, int _tropeChance, Diary _diary, Timer _timer)
    {
        heroID = _heroID;
        adventureModuleID = _adventureModuleID;
        Distance = _distance;
        TropeChance = _tropeChance;

        diary = _diary;
        timer = _timer;
        passedTropesID = new List<Id>();
        _id = new Id("jorney" + _heroID.get());
    }

    [JsonConstructor] //Используется для десериализации данных путешествия
    public JorneyData(Id _id, Id heroID, Id adventureModuleID, Id currentTropeID, float distance, int tropeChance, Diary diary, Timer timer, JorneyState currentState, MovingDirection currentDirection, List<Id> passedTropesID)
    {
        this._id = _id;
        this.adventureModuleID = adventureModuleID;
        this.currentTropeID = currentTropeID;
        this.heroID = heroID;
        this.distance = distance;
        this.tropeChance = tropeChance;
        this.timer = timer;
        this.diary = diary;
        this.currentState = currentState;
        this.currentDirection =currentDirection;
        this.passedTropesID = passedTropesID;
    }

    #endregion Constructors

    //сохранение в файловую систему
    public void save()
    {

        Hero.save();
        TropeDataManager.Instance.saveObject(currentTropeID);
        JorneyDataManager.Instance.saveJorneyData(Id);
    }

    public void setCurrentTrope(TropeInstance trope)
    {
        currentTropeID = trope.Id;
    }

    public void delete()
    {
        JorneyDataManager.Instance.deleteObject(_id);
    }

}
