using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEvent_finishJorney : Event_GameEvent
{
    //сообщает о том, что интерфейс зафиксировал попытку пользователя завершить Jorney
    public Id jorneyID;

    public GUIEvent_finishJorney(Id jorneyID)
    {
        this.jorneyID = jorneyID;
    }
}
