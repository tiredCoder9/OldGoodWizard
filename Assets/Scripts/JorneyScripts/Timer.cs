using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Timer
{
    
    [JsonProperty] [SerializeField] protected double beginDate = GameManager._GLOBAL_TIME_;  //время начала события, поумолчанию равно текущему времени
    [JsonProperty] [SerializeField] protected double tempTime = 0;                           //внутренее время события
    [JsonProperty] [SerializeField] protected double lastTropeTime = 0;                      //время последнего события в минутах
    [JsonProperty] [SerializeField] protected double turnTimeDelay = 0;                      //дополнительная задержка в минутах до следующего обновления jorney
    [JsonProperty] [SerializeField] protected double lastStepTime = 0;


    //реальное время с начала события
    [JsonIgnore] public double actualTime { get { return GameManager._GLOBAL_TIME_ - beginDate; } }
    [JsonIgnore] public double timeSinceLastTrope { get { return tempTime - lastTropeTime; } }
    [JsonIgnore] public double innerTime { get { return tempTime;  } }

    public Timer() { }

    [JsonConstructor]
    public Timer(double beginDate, double tempTime, double lastTropeTime, double turnTimeDelay)
    {
        this.beginDate = beginDate;
        this.tempTime = tempTime;
        this.lastTropeTime = lastTropeTime;
        this.turnTimeDelay = turnTimeDelay;
    }

    public Timer(double beginDate, double turnTimeDelay)
    {
        this.beginDate = beginDate;
        this.turnTimeDelay = turnTimeDelay;
    }

    /// <summary>
    /// Возвращает истину, в текущем кадре началась новая минута
    /// </summary>
    /// <returns></returns>
    public bool turnPassed()
    {
        return tempTime >= lastStepTime + turnTimeDelay;
    }

    //public bool turnPassed(double delay)
    //{
    //    //Debug.Log("Check ->" + tempTime + " <? " + (actualTime + turnTimeDelay));
    //    //Debug.Log(tempTime < actualTime + turnTimeDelay);
    //    return tempTime < actualTime + delay;
    //}

    ///// <summary>
    ///// Необходимо вызывать в каждом обновлении путешествия, чтобы синхронизировать значения внутреннего времени, в противном случае метод будет всегда возвращать истинну
    ///// </summary>
    //public void jorneyTimeContinue()
    //{
    //    if (turnPassed()) tempTime +=turnTimeDelay ;
    //}


    public void updateLastTropeTime()
    {
        lastTropeTime = tempTime;
    }

    public void updateLastStepTime()
    {
        lastStepTime = tempTime;
    }

    public void Update()
    {
        tempTime += Time.deltaTime;  
    }

    public void UnsyncUpdate()
    {
        tempTime += 0.1f;
    }


    public bool TimeIsSync()
    {
        return tempTime >= actualTime;
    }

}
