using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_DiaryChanged : Event_GameEvent
{
    public Id jorneyID;
    public Diary diary;

    public Event_DiaryChanged(Id jorneyID, Diary diary)
    {
        this.jorneyID = jorneyID;
        this.diary = diary;
    }
}
