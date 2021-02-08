using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_HeroDamaged : Event_HeroGameEvent
{
    public int damage;
    public Event_HeroDamaged(Hero _hero, int _damage) : base(_hero)
    {
        damage = _damage;
    }
}
