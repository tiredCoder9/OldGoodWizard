using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_HeroGameEvent : Event_GameEvent
{
    public Hero hero;
    public Event_HeroGameEvent(Hero _hero)
    {
        hero = _hero;
    }
}
