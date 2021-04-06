using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class ActorSkills
{

    [JsonIgnore] protected List<Bonus> rawBonuses;
    [JsonIgnore] protected List<Bonus> finalBonuses;
    [JsonProperty] protected Dictionary<BaseAttribute.AttributeType, SkillAttribute> skillAttributes;
    [JsonProperty] protected Dictionary<BaseAttribute.AttributeType, ResourceAttribute> resourceAttributes;

    [JsonIgnore] public List<SkillAttribute> SkillAttributes
    {
        get
        {
            return skillAttributes.Values.AsEnumerable().ToList();
        }
    }
    [JsonIgnore] public List<ResourceAttribute> ResourceAttributes
    {
        get
        {
            return resourceAttributes.Values.AsEnumerable().ToList();
        }
    }


    [JsonConstructor]
    public ActorSkills(Dictionary<BaseAttribute.AttributeType, SkillAttribute> skillAttributes, Dictionary<BaseAttribute.AttributeType, ResourceAttribute> resourceAttributes)
    {
        this.skillAttributes = skillAttributes;
        this.resourceAttributes = resourceAttributes;
        rawBonuses = new List<Bonus>();
        finalBonuses = new List<Bonus>();
    }

    public ActorSkills(ActorSkills _actor)
    {
        this.skillAttributes = _actor.skillAttributes;
        this.resourceAttributes = _actor.resourceAttributes;
        this.rawBonuses = _actor.rawBonuses;
        this.finalBonuses = _actor.finalBonuses;
    }

    public ActorSkills(List<SkillAttribute> _attributes, List<ResourceAttribute> _resources)
    {
        rawBonuses = new List<Bonus>();
        finalBonuses = new List<Bonus>();
        skillAttributes = new Dictionary<BaseAttribute.AttributeType, SkillAttribute>();

        foreach(var attr in _attributes)
        {
            //Debug.Log(attr.type);
            skillAttributes.Add(attr.type, attr);
        }

        resourceAttributes = new Dictionary<BaseAttribute.AttributeType, ResourceAttribute>();

        foreach(var res in _resources)
        {
            resourceAttributes.Add(res.type, res);
        }
    }

    //chars


    public int GetSkillValue(BaseAttribute.AttributeType type)
    {
        if (skillAttributes.ContainsKey(type))
            return skillAttributes[type].getFinalValue(this);
        return 0;
    }

    public SkillAttribute GetSkillAttribute(BaseAttribute.AttributeType type)
    {
        if (skillAttributes.ContainsKey(type))
            return skillAttributes[type];
        return null;
    }

    public int GetResourceValue(BaseAttribute.AttributeType type)
    {
        if (resourceAttributes.ContainsKey(type))
            return resourceAttributes[type].getCurrentValue(this);
        return 0;
    }

    public ResourceAttribute GetResourceAttribute(BaseAttribute.AttributeType type)
    {
        if (resourceAttributes.ContainsKey(type))
            return resourceAttributes[type];
        return null;
    }

    public void AddToSkillValue(BaseAttribute.AttributeType type, int addition)
    {
        if (skillAttributes.ContainsKey(type)) skillAttributes[type].AddToBaseValue(addition);
        RaiseCalculationFlags();
    }

    public void AddToResourceValue(BaseAttribute.AttributeType type, int addition)
    {
        if (resourceAttributes.ContainsKey(type)) resourceAttributes[type].AddToBaseValue(addition);
        RaiseCalculationFlags();
    }


    public void AddSkill(BaseAttribute.AttributeType type, SkillAttribute attribute)
    {
        skillAttributes.Add(type, attribute);
        RaiseCalculationFlags();
    }

    public void AddResource(BaseAttribute.AttributeType type, ResourceAttribute resource)
    {
        resourceAttributes.Add(type, resource);
        RaiseCalculationFlags();
    }


    public void AddRawBonus(Bonus bonus)
    {
        rawBonuses.Add(bonus);
        RaiseCalculationFlags();
    }

    public void AddFinalBonus(Bonus bonus)
    {
        finalBonuses.Add(bonus);
        RaiseCalculationFlags();
    }

    public void removeRawBonus(Bonus bonus)
    {
      if(rawBonuses.Contains(bonus)) rawBonuses.Remove(bonus);
        RaiseCalculationFlags();
    }

    public void removeFinalBonus(Bonus bonus)
    {
        if(finalBonuses.Contains(bonus))  finalBonuses.Remove(bonus);
        RaiseCalculationFlags();
    }

    public List<Bonus> getRawBonuses(BaseAttribute.AttributeType type)
    {
        return rawBonuses.Where(elem => elem.type == type).ToList();
    }

    public List<Bonus> getFinalBonuses(BaseAttribute.AttributeType type)
    {
        return finalBonuses.Where(elem => elem.type == type).ToList();
    }


    public void RaiseCalculationFlags()
    {
        foreach(var attribute in skillAttributes)
        {
            attribute.Value.setRecalcFlag(false);
        }

        foreach(var res in resourceAttributes)
        {
            res.Value.setRecalcFlag(false);
        }
    }


    public void scatterSkillPoints_Random(int points)
    {
        while (points > 0)
        {
            foreach(var attr in skillAttributes)
            {
                if (points > 0)
                {
                    int increment = Random.Range(0, points+1);
                    points -= increment;
                    attr.Value.AddToBaseValue(increment);
                }
            }
        }
    }


    public bool skillIsPumped(BaseAttribute.AttributeType type, int bonus=0)
    {
        return skillAttributes[type].BaseValue+bonus > skillAttributes[type].MaxValue;
    }

}
