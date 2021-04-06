using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AdventureGenerator))]
public class Jorney : MonoBehaviour
{

    [ReadOnly] public JorneyData values;
    public AdventureGenerator generator { get; set; }
    public bool IsSynchronized;

    private void Start()
    {


        //обновляем путешествие в зависимости от прошедшего времени, пока время не будет синхронизированно
        synchronizeJorney();
        values.save();

        IsSynchronized = true;

        EventSystem.Instance.Raise(new Event_JorneyInitialized(values.Id, this));
        EventSystem.Instance.AddEventListener<GUIEvent_ChangeJorneyDirection>(OnPlayerChangedDirection);


    }

    private void Update()
    {
        DoUpdate();
    }


    //не сохраняет данные, используется когда происходит синхронизация времени 
    private void DynamicUpdate()
    {
        if (values.Hero.isAlive())
        {
            turnPath();
        }
        values.Timer.jorneyTimeContinue();
    }


 
    private void DoUpdate()
    {
        if (values.Hero.isAlive())
        {
            turnPath();
            if(values.Timer.turnPassed()) values.save();
        }
        values.Timer.jorneyTimeContinue();
    }




    private void synchronizeJorney()
    {
        while (values.Timer.turnPassed())
        {
            DynamicUpdate();
        }
    }



    private void turnPath()
    {
     
        switch (values.CurrentState)
        {
            case JorneyData.JorneyState.moving:
                moving();
                break;
            case JorneyData.JorneyState.standingTrope:
                tropeWaiting();
                break;
            case JorneyData.JorneyState.endedFail:
                failedWaiting();
                break;
            case JorneyData.JorneyState.endedReturn:
                returnedWaiting();
                break;
        }
    }

    private void moving()
    {
        //продолжаем путешествие, если начался новый ход 
        if (values.Timer.turnPassed())
        {
            switch (values.CurrentDirection)
            {
                case JorneyData.MovingDirection.forward:
                    movingForward();
                    break;
                case JorneyData.MovingDirection.backward:
                    movingBackward();
                    break;
            }

        }

    }

    private void movingForward()
    {
        if(Randomiser.withChance(values.TropeChance + values.Timer.timeSinceLastTrope * 0.01f))
        {
            TropeInstance nextTrope = generator.getNextTrope(values);
            values.setCurrentTrope(nextTrope);
            values.Timer.updateLastTropeTime();      
            values.CurrentTrope.begin(values);
            EventSystem.Instance.Raise(new Event_TropeStarted(nextTrope, values.Id));
            changeState(JorneyData.JorneyState.standingTrope);
            
        }
        else
        {
            //если не началось событие - продолжаем движение
            values.Distance += (int)values.CurrentDirection * 0.01f * values.Hero.Speed;
        }
    }

    private void movingBackward()
    {
        if (values.Distance > 0)
        {
            if (Randomiser.withChance(0.5f * values.TropeChance + values.Timer.timeSinceLastTrope * 0.01f))
            {
                TropeInstance nextTrope = generator.getNextTrope(values);
                values.setCurrentTrope(nextTrope);
                values.Timer.updateLastTropeTime();
                values.CurrentTrope.begin(values);
                EventSystem.Instance.Raise(new Event_TropeStarted(nextTrope, values.Id));
                changeState(JorneyData.JorneyState.standingTrope);
            }
            else
            {
                //если не началось событие - продолжаем движение
                values.Distance += (int)values.CurrentDirection * 0.01f * values.Hero.Speed;
            }
        }
        else
        {
            changeState(JorneyData.JorneyState.endedReturn);
            EventSystem.Instance.Raise(new Event_JorneyEnded(values.Id));
        }

    }

    private void tropeWaiting()
    {
        if (values.CurrentTrope==null || values.CurrentTrope.ended(values))
        {
            EventSystem.Instance.Raise(new Event_TropeEnded(values.CurrentTrope, values.Id));
            if (!values.Hero.isAlive())
            {
                changeState(JorneyData.JorneyState.endedFail);
                return;
            }  
            
            changeState(JorneyData.JorneyState.moving);
        }
    }

    private void changeState(JorneyData.JorneyState state)
    {
       values.CurrentState = state;
    }

    private void changeDirection(JorneyData.MovingDirection direction)
    {
        values.CurrentDirection = direction;
    }


    private void OnPlayerChangedDirection(GUIEvent_ChangeJorneyDirection e)
    {

        if (values.CurrentState != JorneyData.JorneyState.standingTrope && 
            values.CurrentState != JorneyData.JorneyState.endedReturn &&
            values.CurrentState != JorneyData.JorneyState.endedFail &&
            values.Hero.isAlive())
        {
            if (e.jorneyID == values.Id)
            {
                changeDirection(e.newDirection);
            }
        }
        values.save();
    }


    private void failedWaiting()
    {
        //ничего не делаем... пока что
    }

    private void returnedWaiting()
    {

    }
}
