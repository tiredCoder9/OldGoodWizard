using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


[System.Serializable]
public class Hero : Character, ISaveable, IAppraiseable, ITrainable
{
    [SerializeField] [JsonProperty] private string portraitSpriteName;
    [SerializeField] [JsonProperty] private HeroState state = HeroState.tavern;
    [SerializeField] [JsonProperty] protected ActorSkills actorSkills;
    [SerializeField] [JsonProperty] protected string className;
    [SerializeField] [JsonProperty] protected LevelBehavior levelBehavior;

    [SerializeField] [JsonIgnore] private Sprite portrait;
    private bool dirtyFlag = false;
    

    [JsonIgnore] public string ClassName { get { return className; } }
    [JsonIgnore] public HeroState State
    {
        get
        {
            return state;
        }

        set
        {
            var temp = state;
            state = value;
            EventSystem.Instance.Raise(new Event_HeroStateChanged(temp, this));
        }
    }
    [JsonIgnore] public override ActorSkills ActorSkills { get { return actorSkills; } }
    [JsonIgnore] public LevelBehavior LevelBehavior { get { return levelBehavior; } }

    

    public enum HeroState { tavern, tower, adventure, lost, dead}

    public Sprite getPortrait() { return portrait; }


    

    [JsonConstructor]
    public Hero(Id _id, string name, string portraitSpriteName, ActorSkills actorSkills, LevelBehavior levelBehavior, string className)
    {
        this._id = _id;
        this.entityName = name;
        this.portraitSpriteName = portraitSpriteName;
        this.portrait = Resources.Load<Sprite>("Portraits/" + this.portraitSpriteName);
        this.actorSkills=actorSkills;
        this.className = className;
        this.levelBehavior = levelBehavior;
    }

    public Hero(string _name, string className, ActorSkills actorSkills, LevelBehavior levelBehavior, Sprite _portrait)
    {
        _id = HeroDataManager.Instance.generateGUID();
        entityName = _name;
        portraitSpriteName = _portrait.name;
        portrait = _portrait;
        this.actorSkills = actorSkills;
        this.className = className;
        this.levelBehavior = levelBehavior;
    }




    public long getPrice()
    {
        return ((MaxHealth + MaxMind) * Power) / 2;
    }

    public void levelUp(long levelPoints, Dictionary<BaseAttribute.AttributeType, int> points)
    {
        if (levelPoints <= LevelBehavior.LevelPoints)
        {
            LevelBehavior.spendLevelPoint(levelPoints);

            //upgrade skills
            foreach(var pointBonus in points)
            {
                ActorSkills.AddToSkillValue(pointBonus.Key, pointBonus.Value);
            }

            //increase health and mind

            ActorSkills.AddToResourceValue(BaseAttribute.AttributeType.health, Endurance);
            ActorSkills.AddToResourceValue(BaseAttribute.AttributeType.mind, Sanity);
        }
    }

    public void save()
    {
        this.setDirty(true);
    }


    public void delete()
    {
        HeroDataManager.Instance.deleteObject(_id);
    }


    public bool getDirty()
    {
        return dirtyFlag;
    }

    public void setDirty(bool value)
    {
        dirtyFlag = value;
    }
}
