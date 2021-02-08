using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_JorneyDirectionChanged : Event_JorneyGameEvent
{
    public JorneyData.MovingDirection previousDirection;

    public Event_JorneyDirectionChanged(Id jorneyID, JorneyData.MovingDirection previousDirection) : base(jorneyID)
    {
        this.previousDirection = previousDirection;
    }
}
