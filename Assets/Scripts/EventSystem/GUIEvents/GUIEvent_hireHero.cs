using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEvent_hireHero : Event_GameEvent
{
    public Id heroToHire;

    public GUIEvent_hireHero(Id heroToHire)
    {
        this.heroToHire = heroToHire;
    }
}
