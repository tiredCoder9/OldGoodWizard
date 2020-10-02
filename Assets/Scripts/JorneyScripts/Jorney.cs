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
        values.adventureGenerator = GetComponent<AdventureGenerator>();
        
        updateJorneyData();
    }

    private void Update()
    {

        if (values.timer.turnPassed() && values.hero.isAlive())
        {
            turnPath();        
        }
    }

    private void LateUpdate()
    {
        values.timer.jorneyTimeContinue();
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

    public void movingForward()
    {
        if(Randomiser.withChance(values.tropeChance + values.timer.timeSinceLastTrope * 0.01f))
        {
            values.currentTrope = values.adventureGenerator.getNextTrope(this);
            values.timer.updateLastTropeTime();
            values.currentTrope.begin(values);
            changeState(JorneyData.State.standingTrope);
        }
    }

    public void movingBackward()
    {

    }

    public void standingTrope()
    {
        if (values.currentTrope==null || values.currentTrope.end(values))
        {
            changeState(JorneyData.State.moving);
        }
    }

    public void changeState(JorneyData.State state)
    {

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

    /// <summary>
    /// Возвращает истинну, если в текущем кадре началась новая минута относительно времени данного путешествия.
    /// </summary>
    /// <returns></returns>

}
