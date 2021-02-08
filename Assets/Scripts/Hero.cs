using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


[System.Serializable]
public class Hero: Character, ISaveable, IAppraiseable
{

    [SerializeField] [JsonProperty] private int nativeSanity = 1;
    [SerializeField] [JsonProperty] private string portraitSpriteName;
    [SerializeField] [JsonProperty] private HeroState state = HeroState.tavern;
    [SerializeField] [JsonProperty] protected ActorSkills actorSkills;
    [SerializeField] [JsonProperty] protected string className;
    [SerializeField] [JsonIgnore]   private Sprite portrait;



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
    [JsonIgnore] public int NativeSanity
    { 
        get
        {
            return nativeSanity;
        } 
    }
    [JsonIgnore] public override ActorSkills ActorSkills { get { return actorSkills;  } }


    public enum HeroState { tavern, tower, adventure, lost, dead}

    public Sprite getPortrait() { return portrait; }
    

    [JsonConstructor]
    public Hero(Id _id, string name, string portraitSpriteName, ActorSkills actorSkills, string className)
    {
        this._id = _id;
        this.entityName = name;
        this.portraitSpriteName = portraitSpriteName;
        this.portrait = Resources.Load<Sprite>("Portraits/" + this.portraitSpriteName);
        this.actorSkills=actorSkills;
        this.className = className;
    }

    public Hero(string _name, string className, ActorSkills actorSkills, Sprite _portrait)
    {
        _id = HeroDataManager.Instance.generateGUID();
        entityName = _name;
        portraitSpriteName = _portrait.name;
        portrait = _portrait;
        this.actorSkills = actorSkills;
        this.className = className;
    }


    public void save()
    {
        HeroDataManager.Instance.saveHeroState(_id);
    }


    public void delete()
    {
        HeroDataManager.Instance.deleteObject(_id);
    }

    public long getPrice()
    {
        return ((MaxHealth + MaxMind) * Power) / 2;
    }
}
