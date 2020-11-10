using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AdventureGenerator))]
public class Jorney : MonoBehaviour
{

    [ReadOnly] public JorneyData values;
    public AdventureGenerator generator { get; set; }

    private void Start()
    {

        //обновляем путешествие в зависимости от прошедшего времени, пока время не будет синхронизированно
        synchronizeJorney();

        values.save();
        
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
                standingTrope();
                break;
        }
    }

    public void moving()
    {
        //продолжаем путешествие, если начался новый ход 
        if (values.Timer.turnPassed())
        {
            values.Distance += (int)values.CurrentDirection * 0.1f;

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

    public void movingForward()
    {
        if(Randomiser.withChance(values.TropeChance + values.Timer.timeSinceLastTrope * 0.01f))
        {
            values.setCurrentTrope(generator.getNextTrope(values));
            values.Timer.updateLastTropeTime();      
            values.CurrentTrope.begin(values);
          
            changeState(JorneyData.JorneyState.standingTrope);

            
        }
    }

    public void movingBackward()
    {

    }

    public void standingTrope()
    {
        if (values.CurrentTrope==null || values.CurrentTrope.ended(values))
        {
            changeState(JorneyData.JorneyState.moving);
        }
    }

    public void changeState(JorneyData.JorneyState state)
    {

        values.CurrentState = state;
        values.save();
    }


    public void writeInJournal(string text)
    {
        print(text);
    }


}
