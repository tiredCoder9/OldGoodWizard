using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_TropeGameEvent : Event_JorneyGameEvent
{
    public TropeInstance trope;

    public Event_TropeGameEvent(TropeInstance trope, Id jorneyID) : base(jorneyID)
    {
        this.trope = trope;
        this.jorneyID = jorneyID;
    }
}
