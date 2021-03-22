using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillsViewList : ViewListGroup<AttributePoint, SkillView>
{
    private Dictionary<BaseAttribute.AttributeType, AttributePoint> skillValues;


    public void resetList(Hero hero)
    {
        skillValues = new Dictionary<BaseAttribute.AttributeType, AttributePoint>();
        var skills = hero.ActorSkills.SkillAttributes;

        foreach (SkillAttribute skill in skills)
        {
            skillValues.Add(skill.type, new AttributePoint(skill.getFinalValue(hero.ActorSkills), 0, skill));
        }

        updateGroup(skillValues.Values.ToList());
    }

    public void clearList(Hero hero)
    {

    }
}
