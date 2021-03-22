using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEvent_upgradeSkills : Event_GameEvent
{
    public Hero hero;
    public Dictionary<BaseAttribute.AttributeType, int> points;

    public GUIEvent_upgradeSkills(Hero hero, Dictionary<BaseAttribute.AttributeType, int> points)
    {
        this.hero = hero;
        this.points = points;
    }
}
