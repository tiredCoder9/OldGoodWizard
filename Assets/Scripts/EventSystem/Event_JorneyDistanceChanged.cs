using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_JorneyDistanceChanged : Event_JorneyGameEvent
{
    public float distance;

    public Event_JorneyDistanceChanged(Id jorneyID, float distance) : base(jorneyID)
    {
        this.distance = distance;
    }
}
