using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JorneyData 
{
    //этот обьект содержит только данные, аккумулируя в себе всю информацию конкретного путешествия

    [ReadOnly] public Hero hero;
    public long heroID;
    public float distance = 0;

    public string id
    {
        get
        {
            return heroID + "_jorney";
        }
    }

    public long beginDate=0;
    public long actualTime { get { return GameManager._GLOBAL_TIME_ - beginDate; } }
    public long tempTime = 0;
    public long lastTropeTime = 0;
    //time delay beetween updates event
    public long turnTimeDelay = 0;


    public Queue<long> passedTropesID;
    public Trope currentTrope;
    public AdventureModule mainModule;
    public AdventureGenerator adventureGenerator;
    public Diary diary;

    //направление движения персонажа
    public enum State {moving, standingTrope}
    public State currentState = State.moving;
    public enum Dicection { forward=1, backward=-1}
    public Dicection currentDirection = Dicection.forward;

    public void save()
    {
        HeroDataManager.Instance.saveHeroState(heroID);
        JorneyDataManager.saveJorneyData(id);
    }
}
