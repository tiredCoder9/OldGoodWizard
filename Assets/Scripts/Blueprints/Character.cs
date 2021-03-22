using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public abstract class Character : Entity, IActor
{
    [JsonProperty] [SerializeField] protected Gender gender = Gender.unknown;

    [JsonIgnore] public Gender EntityGender { get { return gender; } }
    public enum Gender { male, female, unknown }
    public abstract ActorSkills ActorSkills { get; }


    [JsonIgnore] public virtual int Power { get { return ActorSkills.GetSkillValue(BaseAttribute.AttributeType.power); } }
    [JsonIgnore] public virtual int Endurance { get { return ActorSkills.GetSkillValue(BaseAttribute.AttributeType.endurance); } }
    [JsonIgnore] public virtual int Sanity { get { return ActorSkills.GetSkillValue(BaseAttribute.AttributeType.sanity); } }
    [JsonIgnore] public virtual int Speed { get { return ActorSkills.GetSkillValue(BaseAttribute.AttributeType.speed); } }

    [JsonIgnore] public virtual int Luck { get { return ActorSkills.GetSkillValue(BaseAttribute.AttributeType.luck); } }
    [JsonIgnore] public virtual int Wisdom { get { return ActorSkills.GetSkillValue(BaseAttribute.AttributeType.wisdom); } }
    [JsonIgnore] public virtual int Speechcraft { get { return ActorSkills.GetSkillValue(BaseAttribute.AttributeType.speechcraft); } }
    [JsonIgnore] public virtual int Trade { get { return ActorSkills.GetSkillValue(BaseAttribute.AttributeType.trade); } }


    [JsonIgnore] public virtual int MaxMind { get { return ActorSkills.GetResourceAttribute(BaseAttribute.AttributeType.mind).getFinalValue(ActorSkills); } }
    [JsonIgnore] public virtual int MaxHealth { get { return ActorSkills.GetResourceAttribute(BaseAttribute.AttributeType.health).getFinalValue(ActorSkills); } }
    [JsonIgnore] public virtual int CurrentMind { get { return ActorSkills.GetResourceValue(BaseAttribute.AttributeType.mind); } }
    [JsonIgnore] public virtual int CurrentHealth { get { return ActorSkills.GetResourceValue(BaseAttribute.AttributeType.health); } }

    public int generateDamageValue()
    {
        int power = Power;

        int bottomEdge = (int)(power + (Luck * 0.3));

        int upperEdge = power * 2;

        return Random.Range(bottomEdge, upperEdge);
    }

    public virtual bool dealDamage(int damage)
    {
        var health = ActorSkills.GetResourceAttribute(BaseAttribute.AttributeType.health);

        if (health != null)
        {
            Debug.Log("damage dealed - "+damage);
            health.addToCurrentValue(-damage);
            return health.IsExhausted();
        }
        return false;
    }

    public virtual bool dealSanityDamage(int damage)
    {
        var mind = ActorSkills.GetResourceAttribute(BaseAttribute.AttributeType.mind);

        if (mind != null)
        {
            mind.addToCurrentValue(-damage);
            return mind.IsExhausted();
        }
        return false;
    }

    public virtual bool isAlive()
    {
        return !ActorSkills.GetResourceAttribute(BaseAttribute.AttributeType.health).IsExhausted();
    }

    public virtual bool isSane()
    {
        return !ActorSkills.GetResourceAttribute(BaseAttribute.AttributeType.mind).IsExhausted();
    }




}
