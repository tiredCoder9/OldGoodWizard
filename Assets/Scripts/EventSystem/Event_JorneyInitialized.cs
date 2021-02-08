using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_JorneyInitialized : Event_JorneyGameEvent
{
    public Jorney behaviour;

    public Event_JorneyInitialized(Id jorneyID, Jorney behaviour) : base(jorneyID)
    {
        this.behaviour = behaviour;
    }
}
