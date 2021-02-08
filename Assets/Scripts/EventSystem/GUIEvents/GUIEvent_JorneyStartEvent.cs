using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEvent_JorneyStartEvent : Event_GameEvent
{
    //сообщает о том что интерфейс зафиксировал попытку пользователя отправить героя в путешествие
    public Id heroID;
    public Id adventureModuleID;

    public GUIEvent_JorneyStartEvent(Id heroID, Id adventureModuleID)
    {
        this.heroID = heroID;
        this.adventureModuleID = adventureModuleID;
    }
}
