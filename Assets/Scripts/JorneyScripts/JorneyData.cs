using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

[System.Serializable]
public class JorneyData : Saveable
{
    //этот обьект содержит только данные, аккумулируя в себе всю информацию конкретного путешествия

    public Hero hero { get { return HeroDataManager.Instance.getHeroByID(heroID); } }
    //идентификатор героя
    public Id heroID;
    //пройденное расстояние
    public float distance = 0;
    //шанс появления события
    public int tropeChance = 5;
    //составной идентификатор


    //отвечает за внутренее время путешествия
    public Timer timer;

    //очередь пройденных событий
    public Queue<long> passedTropesID;
    //текущее событие
    public Trope currentTrope;
    public long currentTropeID=0;
    //модуль ресурсов событий
    public AdventureModule mainModule;
    //лог текстовых сообщений событий
    public Diary diary;

    //состояние путешествия - передвижение/происходит событие
    public enum State {moving, standingTrope}
    public State currentState = State.moving;
    //направление движения вперед/назад
    public enum Dicection { forward=1, backward=-1}
    public Dicection currentDirection = Dicection.forward;

    public JorneyData(Id _heroID)
    {
        heroID = _heroID;
        testID = new Id("jorney" + _heroID.get());
        diary = new Diary();
        timer = new Timer();
    }

    //сохранение в файловую систему
    public  void save()
    {
        HeroDataManager.Instance.saveHeroState(heroID);
        JorneyDataManager.Instance.saveJorneyData(testID);
    }

    public void load()
    {
        currentTrope = TropeManager.getTropeById(currentTropeID);
    }




}
