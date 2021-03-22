using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AttributePoint
{
    public int value;
    public int bonus;
    public SkillAttribute attribute;

    public AttributePoint(int value, int bonus, SkillAttribute attribute)
    {
        this.value = value;
        this.bonus = bonus;
        this.attribute = attribute;
    }
    
}
