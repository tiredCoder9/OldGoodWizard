using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Timer
{
    
    [JsonProperty] [SerializeField] protected long beginDate = GameManager._GLOBAL_TIME_;  //время начала события, поумолчанию равно текущему времени
    [JsonProperty] [SerializeField] protected long tempTime = 0;                           //внутренее время события
    [JsonProperty] [SerializeField] protected long lastTropeTime = 0;                      //время последнего события в минутах
    [JsonProperty] [SerializeField] protected long turnTimeDelay = 0;                      //дополнительная задержка в минутах до следующего обновления jorney


    //реальное время с начала события
    [JsonIgnore] public long actualTime { get { return GameManager._GLOBAL_TIME_ - beginDate; } }
    [JsonIgnore] public long timeSinceLastTrope { get { return tempTime - lastTropeTime; } }
    [JsonIgnore] public long innerTime { get { return tempTime;  } }

    public Timer() { }

    [JsonConstructor]
    public Timer(long beginDate, long tempTime, long lastTropeTime, long turnTimeDelay)
    {
        this.beginDate = beginDate;
        this.tempTime = tempTime;
        this.lastTropeTime = lastTropeTime;
        this.turnTimeDelay = turnTimeDelay;
    }

    public Timer(long beginDate, long turnTimeDelay)
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
        //Debug.Log("Check ->" + tempTime + " <? " + (actualTime + turnTimeDelay));
        //Debug.Log(tempTime < actualTime + turnTimeDelay);
        return tempTime < actualTime + turnTimeDelay;
    }

    /// <summary>
    /// Необходимо вызывать в каждом обновлении путешествия, чтобы синхронизировать значения внутреннего времени, в противном случае метод будет всегда возвращать истинну
    /// </summary>
    public void jorneyTimeContinue()
    {
        if (turnPassed()) tempTime++;
    }


    public void updateLastTropeTime()
    {
        lastTropeTime = tempTime;
    }


}
