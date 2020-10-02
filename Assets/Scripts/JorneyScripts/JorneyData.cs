using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JorneyData 
{
    //этот обьект содержит только данные, аккумулируя в себе всю информацию конкретного путешествия

    [ReadOnly] public Hero hero;
    //идентификатор героя
    public long heroID;
    //пройденное расстояние
    public float distance = 0;
    //шанс появления события
    public int tropeChance = 5;
    //составной идентификатор
    public string id
    {
        get
        {
            return heroID + "_jorney";
        }
    }


    //отвечает за внутренее время путешествия
    public Timer timer;

    //очередь пройденных событий
    public Queue<long> passedTropesID;
    //текущее событие
    public Trope currentTrope;
    //модуль ресурсов событий
    public AdventureModule mainModule;
    //генератор событий
    public AdventureGenerator adventureGenerator;
    //лог текстовых сообщений событий
    public Diary diary;

    //состояние путешествия - передвижение/происходит событие
    public enum State {moving, standingTrope}
    public State currentState = State.moving;
    //направление движения вперед/назад
    public enum Dicection { forward=1, backward=-1}
    public Dicection currentDirection = Dicection.forward;

    //сохранение в файловую систему
    public void save()
    {
        HeroDataManager.Instance.saveHeroState(heroID);
        JorneyDataManager.saveJorneyData(id);
    }

    
    
}
