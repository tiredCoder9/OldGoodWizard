using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_JorneyStateChanged : Event_JorneyGameEvent
{
    JorneyData.JorneyState previousState;

    public Event_JorneyStateChanged(Id jorneyID, JorneyData.JorneyState previousState) : base(jorneyID)
    {
        this.previousState = previousState;
    }
}
