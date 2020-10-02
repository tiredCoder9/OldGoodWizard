using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Timer
{
    //время начала события, поумолчанию равно текущему времени
    [SerializeField]
    protected long beginDate = GameManager._GLOBAL_TIME_;

    //внутренее время события
    [SerializeField]
    protected long tempTime = 0;

    //время последнего события в минутах
    [SerializeField]
    protected long lastTropeTime = 0;

    //дополнительная задержка в минутах до следующего обновления jorney
    [SerializeField]
    protected long turnTimeDelay = 0;


    //реальное время с начала события
    public long actualTime { get { return GameManager._GLOBAL_TIME_ - beginDate; } }

    public long timeSinceLastTrope { get { return tempTime - lastTropeTime; } }

    public long innerTime { get { return tempTime;  } }

    /// <summary>
    /// Возвращает истину, в текущем кадре началась новая минута
    /// </summary>
    /// <returns></returns>
    public bool turnPassed()
    {
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
