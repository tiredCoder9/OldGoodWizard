using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEvent_ChangeJorneyDirection : Event_GameEvent
{
    public Id jorneyID;
    public JorneyData.MovingDirection newDirection;

    public GUIEvent_ChangeJorneyDirection(Id jorneyID, JorneyData.MovingDirection newDirection)
    {
        this.jorneyID = jorneyID;
        this.newDirection = newDirection;
    }
}
