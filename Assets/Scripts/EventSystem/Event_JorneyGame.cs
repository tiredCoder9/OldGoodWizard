using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_JorneyGameEvent : Event_GameEvent
{
    public Id jorneyID;

    public Event_JorneyGameEvent(Id jorneyID)
    {
        this.jorneyID = jorneyID;
    }
}
