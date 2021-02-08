using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class BaseAttribute 
{
    protected int baseValue;
    protected int baseMultiplier;
    [JsonProperty] protected bool IsRecalculated = false;

    public int BaseValue { get => baseValue;}
    public int BaseMultiplier { get => baseMultiplier;}

    public enum AttributeType {power, speed,  endurance, sanity, luck, wisdom, speechcraft, trade, health, mind, placeholder}
    public AttributeType type = AttributeType.placeholder;

    [JsonConstructor]
    public BaseAttribute(int baseValue, bool IsRecalculated, int baseMultiplier=0)
    {
        this.baseValue = baseValue;
        this.baseMultiplier = baseMultiplier;
        this.IsRecalculated = IsRecalculated;
    }


    public virtual int getFinalValue(ActorSkills actorFeatures)
    {
        IsRecalculated = true;
        return baseValue;
    }


    public virtual int getFinalMultiplier(ActorSkills actorFeatures)
    {
        IsRecalculated = true;
        return baseMultiplier;
    }


    public void setRecalcFlag(bool recalc)
    {
        IsRecalculated = recalc;
    }

    public virtual void AddToBaseValue(int value)
    {
        baseValue += value;
    }


}
