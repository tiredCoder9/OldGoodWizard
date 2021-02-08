using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ResourceAttribute : BaseAttribute
{

    [JsonProperty] protected int finalValue;
    [JsonProperty] protected int currentValue;


    public ResourceAttribute(int baseValue, int baseMultiplier = 0) : base(baseValue, false, baseMultiplier)
    {
        finalValue = baseValue;
        currentValue = baseValue;
    }

    [JsonConstructor]
    public ResourceAttribute(int baseValue, bool IsRecalculated, int currentValue, int finalValue, int baseMultiplier=0): base(baseValue, IsRecalculated, baseMultiplier)
    {
        this.currentValue = currentValue;
        this.finalValue = finalValue;
    } 

    public int getCurrentValue(ActorSkills actor)
    {
        int finalValue = getFinalValue(actor);
        if (currentValue > finalValue) currentValue = finalValue;
        if (currentValue < 0) currentValue = 0;

        return currentValue;
    }

    public bool IsExhausted()
    {
        return currentValue <= 0;
    }

    public void addToCurrentValue(int value)
    {
        currentValue += value;
    }

    public override int getFinalValue(ActorSkills actorFeatures)
    {
        return calculateFinalValue(actorFeatures);
    }


    protected void applyRawBonuses(ActorSkills actorSkill)
    {
        var rawBonuses = actorSkill.getRawBonuses(type);

        int rawBonusValue = 0;
        int rawBonusMultiplier = 0;
        foreach (var bonus in rawBonuses)
        {
            rawBonusValue += bonus.getFinalValue(actorSkill);
            rawBonusMultiplier += bonus.getFinalMultiplier(actorSkill);
        }

        finalValue += rawBonusValue;
        finalValue *= (rawBonusMultiplier + 1);
    }

    protected void applyFinalBonuses(ActorSkills actorSkills)
    {
        var finalBonuses = actorSkills.getFinalBonuses(type);

        int finalBonusValue = 0;
        int finalBonusMultiplier = 0;
        foreach (var bonus in finalBonuses)
        {
            finalBonusValue += bonus.getFinalValue(actorSkills);
            finalBonusMultiplier += bonus.getFinalMultiplier(actorSkills);
        }

        finalValue += finalBonusValue;
        finalValue *= (finalBonusMultiplier + 1);
    }

    public virtual int calculateFinalValue(ActorSkills actorFeatures)
    {
        if (!IsRecalculated)
        {
            finalValue = baseValue;

            applyRawBonuses(actorFeatures);

            applyFinalBonuses(actorFeatures);

            IsRecalculated = true;
        }

        return finalValue;
    }
}
