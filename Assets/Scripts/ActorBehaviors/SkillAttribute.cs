using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SkillAttribute : BaseAttribute
{

    [JsonProperty] protected int finalValue;
    [JsonProperty] protected int maxValue;
    




    public SkillAttribute(int baseValue, int maxValue = 100, int baseMultiplier = 0) : base(baseValue, false, baseMultiplier)
    {
        finalValue = baseValue;
        this.maxValue = maxValue;
    }

    [JsonConstructor]
    public SkillAttribute(int baseValue, int maxValue, int baseMultiplier, int finalValue, bool IsRecalculated) : base(baseValue, IsRecalculated, baseMultiplier)
    {
        this.maxValue = maxValue;
        this.finalValue = finalValue;

    }

    public void applyFinalBonuses(ActorSkills actorFeatures)
    {
        var finalBonuses = actorFeatures.getFinalBonuses(type);

        int finalBonusValue=0;
        int finalBonusMultiplier=0;
        foreach(var bonus in finalBonuses)
        {
            finalBonusValue += bonus.getFinalValue(actorFeatures);
            finalBonusMultiplier += bonus.getFinalMultiplier(actorFeatures);
        }

        finalValue += finalBonusValue;
        finalValue *= (finalBonusMultiplier + 1);
    }

    public void applyRawBonuses(ActorSkills actorFeatures)
    {
        var rawBonuses = actorFeatures.getRawBonuses(type);

        int rawBonusValue = 0;
        int rawBonusMultiplier = 0;
        foreach (var bonus in rawBonuses)
        {
            rawBonusValue += bonus.getFinalValue(actorFeatures);
            rawBonusMultiplier += bonus.getFinalMultiplier(actorFeatures);
        }

        finalValue += rawBonusValue;
        finalValue *= (rawBonusMultiplier + 1);
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

    public override int getFinalValue(ActorSkills actorFeatures)
    {
        return calculateFinalValue(actorFeatures);
    }

    public override void AddToBaseValue(int value)
    {
        baseValue += value;
        if (baseValue< 0) baseValue = 0;
        if (baseValue > maxValue) baseValue = maxValue;
    }




    
    


}
