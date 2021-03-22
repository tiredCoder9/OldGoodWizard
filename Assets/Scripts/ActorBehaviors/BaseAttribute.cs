using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class BaseAttribute 
{
    public enum AttributeType { power, speed, endurance, sanity, luck, wisdom, speechcraft, trade, health, mind, placeholder }

    [SerializeField] [JsonProperty] protected int baseValue;
    [SerializeField] [JsonProperty] protected int baseMultiplier=1;
    [JsonProperty] protected bool IsRecalculated = false;
    [JsonProperty] public AttributeType type = AttributeType.placeholder;

    [JsonIgnore] public int BaseValue { get => baseValue;}
    [JsonIgnore] public int BaseMultiplier { get => baseMultiplier;}
    [JsonIgnore] public static Dictionary<BaseAttribute.AttributeType, string> attributeLNames = new Dictionary<AttributeType, string>()
    {
        { AttributeType.power, "Могущество" },
        { AttributeType.endurance, "Выносливость"},
        { AttributeType.sanity, "Здравомыслие"},
        { AttributeType.speed, "Скорость"},

        { AttributeType.luck, "Удача"},
        { AttributeType.trade, "Торговля"},
        { AttributeType.speechcraft, "Красноречие"},
        { AttributeType.wisdom, "Мудрость"},

    };


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
