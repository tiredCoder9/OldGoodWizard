using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_HeroStateChanged : Event_HeroGameEvent
{
    public Hero.HeroState previousState;

    public Event_HeroStateChanged(Hero.HeroState _previousState, Hero _hero) : base(_hero)
    {
        previousState = _previousState;
    }
}
