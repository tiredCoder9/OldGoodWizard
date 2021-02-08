using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependentAttribute : SkillAttribute
{

    protected int valueDivisor = 1;

    protected AttributeType dependentType;


    public DependentAttribute(int baseValue, int dependentAttributeValue, int maxValue = 100, int baseMultiplier = 0) : base(baseValue, maxValue, baseMultiplier)
    {
        finalValue = baseValue;
        finalValue = getDependantBonusValue(dependentAttributeValue);
    }

    public DependentAttribute(int baseValue, int maxValue, int baseMultiplier, int finalValue, bool IsRecalculated) : base(baseValue, maxValue, baseMultiplier, finalValue, IsRecalculated)
    {

    }

   
    public virtual void applyDependentAttributeBonus(ActorSkills actor, AttributeType type)
    {
        finalValue += getDependantBonusValue(actor.GetSkillValue(type));
    }

    public virtual int getDependantBonusValue(int dependentAttrValue)
    {
        return dependentAttrValue / valueDivisor;
    }

    public override int calculateFinalValue(ActorSkills actorFeatures)
    {
        if (!IsRecalculated)
        {
            finalValue = baseValue;

            applyDependentAttributeBonus(actorFeatures, dependentType);
            applyRawBonuses(actorFeatures);
            applyFinalBonuses(actorFeatures);

            IsRecalculated = true;
        }
        return finalValue;
        
    }


}
