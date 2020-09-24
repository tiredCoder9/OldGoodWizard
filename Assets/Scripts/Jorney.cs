using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AdventureGenerator))]
public class Jorney : MonoBehaviour
{

    [ReadOnly] public JorneyData values;
    /// <summary>
    /// Вызывается при обработке события каждый Tick, пока оно не завершится
    /// </summary>
    public UnityAction OnJorneyTropeTick;


    private void Start()
    {

        //если время начала не установлено то выставить текущее время начала путешествия.
        if (values.beginDate == 0) values.beginDate = GameManager._GLOBAL_TIME_;

        //получение героя через ID
        values.hero = HeroDataManager.Instance.getHeroByID(values.heroID);
        values.adventureGenerator = GetComponent<AdventureGenerator>();
        
        updateJorneyData();
    }

    private void Update()
    {

        if (values.tempTime < values.actualTime + values.turnTimeDelay && values.hero.isAlive())
        {
            values.tempTime++;
            turnPath();
        }
    }





    private void turnPath()
    {
        values.distance += (int)values.currentDirection*0.1f;

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

    public void movingForward()
    {
        if(Randomiser.withChance(10 + (values.tempTime - values.lastTropeTime) * 0.1f))
        {
            values.currentTrope = values.adventureGenerator.getNextTrope(this);
            values.lastTropeTime = values.tempTime;
            values.currentTrope.execute(values);
            changeState(JorneyData.State.standingTrope);
        }
    }

    public void movingBackward()
    {

    }

    public void standingTrope()
    {
        

        if (values.currentTrope==null || values.currentTrope.done(values))
        {
            changeState(JorneyData.State.moving);
        }
    }

    public void changeState(JorneyData.State state)
    {
        OnJorneyTropeTick.Invoke();
        values.currentState = state;
        updateJorneyData();
    }


    public void writeInJournal(string text)
    {
        print(text);
    }


    public void updateJorneyData()
    {
        values.save();
    }
}
