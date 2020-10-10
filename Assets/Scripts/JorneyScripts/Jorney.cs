using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AdventureGenerator))]
public class Jorney : MonoBehaviour
{

    [ReadOnly] public JorneyData values;

    private void Start()
    {

        //получение героя через ID
        values.hero = HeroDataManager.Instance.getHeroByID(values.heroID);

        //получение ссылки на генератор
        values.adventureGenerator = GetComponent<AdventureGenerator>();

        //получение события через ID
        values.currentTrope = TropeManager.getTropeById(values.currentTropeID);

        //обновляем путешествие в зависимости от прошедшего времени, пока время не будет синхронизированно
        synchronizeJorney();

        values.save();
    }

    private void Update()
    {
        DoUpdate();
    }


    private void DoUpdate()
    {
        if (values.hero.isAlive())
        {
            turnPath();
        }
        values.timer.jorneyTimeContinue();

    }





    private void synchronizeJorney()
    {
        while (values.timer.turnPassed())
        {
            DoUpdate();
        }
    }



    private void turnPath()
    {
     
        switch (values.currentState)
        {
            case JorneyData.State.moving:
                moving();
                break;

            case JorneyData.State.standingTrope:
                standingTrope();
                break;
        }
    }

    public void moving()
    {
        //продолжаем путешествие, если начался новый ход 
        if (values.timer.turnPassed())
        {
            values.distance += (int)values.currentDirection * 0.1f;

            switch (values.currentDirection)
            {
                case JorneyData.Dicection.forward:
                    movingForward();
                    break;
                case JorneyData.Dicection.backward:
                    movingBackward();
                    break;
            }
        }

    }

    public void movingForward()
    {
        if(Randomiser.withChance(values.tropeChance + values.timer.timeSinceLastTrope * 0.01f))
        {
            values.currentTrope = values.adventureGenerator.getNextTrope(this);
            values.timer.updateLastTropeTime();
            values.currentTrope.begin(values);
            values.currentTropeID = values.currentTrope.id;
            changeState(JorneyData.State.standingTrope);
        }
    }

    public void movingBackward()
    {

    }

    public void standingTrope()
    {
        if (values.currentTrope==null || values.currentTrope.ended(values))
        {
            changeState(JorneyData.State.moving);
        }
    }

    public void changeState(JorneyData.State state)
    {

        values.currentState = state;
        values.save();
    }


    public void writeInJournal(string text)
    {
        print(text);
    }


}
