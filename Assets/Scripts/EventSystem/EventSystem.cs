using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventSystem : Singletone<EventSystem>
{
    public delegate void EventDelegate<T>(T e) where T : Event_GameEvent;
    private delegate void EventDelegate(Event_GameEvent e);

    private Dictionary<System.Type, EventDelegate> delegates = new Dictionary<System.Type, EventDelegate>();

    //нужен для проверки копий делегатов
    private Dictionary<System.Delegate, EventDelegate> delegateCopyControl = new Dictionary<System.Delegate, EventDelegate>();

    public void AddEventListener<T> (EventDelegate<T> del) where T: Event_GameEvent
    {
        if (delegateCopyControl.ContainsKey(del))
        {
            Debug.Log("Delegate:" + del.GetType() + del.ToString() + " already added");
            return;
        }
        System.Type tempType = typeof(T);

        //Создаем новый делегат без дженерика который вызывает наш дженерик делегат
        //Это делегат будет вызван при событиии
        EventDelegate internalDelegate = (e) => del((T)e);
        //добавляем 
        delegateCopyControl[del] = internalDelegate;
        EventDelegate tempDelegate;
        if(delegates.TryGetValue(tempType, out tempDelegate))
        {
            //делегат такого типа уже был добавляем, добавляем новый к его вызову.
            delegates[tempType] = tempDelegate += internalDelegate;
        }
        else
        {
            //такого делегата еще не было, просто добавляем его в словарь
            delegates[tempType] = internalDelegate;
        }
    }

    public void RemoveEventListener<T>(EventDelegate<T> del) where T : Event_GameEvent
    {
        EventDelegate internalDelegate;
        if (delegateCopyControl.TryGetValue(del, out internalDelegate))
        {
            EventDelegate tempDel;
            if(delegates.TryGetValue(typeof(T), out tempDel))
            {
                tempDel -= internalDelegate;
                if (tempDel == null)
                {
                    delegates.Remove(typeof(T));
                }
                else
                {
                    delegates[typeof(T)] = tempDel;
                }
            }
            delegateCopyControl.Remove(del);
        }
    }

    public void Raise(Event_GameEvent e)
    {
        Debug.Log("EVENT SYSTEM: event raised - " + e.GetType().Name);

        EventDelegate del;
        if(delegates.TryGetValue(e.GetType(), out del))
        {
            del.Invoke(e);
        }
    }

}







