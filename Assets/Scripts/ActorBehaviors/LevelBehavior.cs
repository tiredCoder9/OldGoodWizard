using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class LevelBehavior 
{
    [JsonProperty] protected int currentLevel = 1;
    [JsonProperty] protected int maxLevel;

    [JsonProperty] protected long currentExperience;

    [JsonProperty] protected long levelPoints;
    [JsonProperty] protected long globalLevelPoints=0;

    [JsonIgnore] public long RequiredExperience { get { return CurrentLevel * 10 * ((CurrentLevel / MaxLevel) +1); } }
    [JsonIgnore] public int CurrentLevel { get => currentLevel;}
    [JsonIgnore] public int MaxLevel { get => maxLevel;  }
    [JsonIgnore] public long CurrentExperience { get => currentExperience;  }
    [JsonIgnore] public long LevelPoints { get => levelPoints;  }

    [JsonIgnore] public long SkillPoints { get => levelPoints*5; }



    [JsonConstructor]
    public LevelBehavior(int currentLevel, int maxLevel, long currentExperience, long levelPoints, long globalLevelPoints)
    {
        this.currentLevel = currentLevel;
        this.maxLevel = maxLevel;
        this.currentExperience = currentExperience;
        this.levelPoints=levelPoints;
        this.globalLevelPoints = globalLevelPoints;
    }

    public LevelBehavior(int currentLevel=1, int maxLevel=100)
    {
        this.currentLevel = currentLevel;
        this.maxLevel = maxLevel;
        levelPoints = 1 - currentLevel;
    }



    public void addExperience(long experience)
    {
        if (experience > 0 && currentLevel<=maxLevel)
        {
            currentExperience += experience;
            if (IsLevelGained()) increaseLevel();
        }
        
    }

    protected void increaseLevel()
    {
        if (IsLevelGained() && currentLevel >= maxLevel)
        {
            currentLevel += 1;
            currentExperience %= RequiredExperience;
            levelPoints += 1;
            globalLevelPoints += 1; 
            if (IsLevelGained()) increaseLevel();
        }
    }

    public bool IsLevelGained()
    {
        return CurrentExperience >= RequiredExperience;
    }

    public void spendLevelPoint(long points)
    {
        if (levelPoints - points >= 0)
        {
            levelPoints -= points;
        }
    }



}
