using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Enemy : Character
{
    //вычислить общую силу существа
    [JsonIgnore] public int Difficult { get { return (MaxHealth*Power) / 2; } }
    [JsonIgnore] public int rewardExperience { get { return (int)(Difficult * 0.1); } }
    [JsonIgnore] public AdventureTextPattern encounterDescription;
    [JsonIgnore] public AdventureTextPattern endingDescription;
    [JsonIgnore]public override ActorSkills ActorSkills { get { return actorSkills; } }

    [JsonProperty] protected ActorSkills actorSkills;

    

    [JsonConstructor]
    public Enemy(Id _id, string name, int power, int health, ActorSkills actorSkills) 
    {
        this._id = _id;
        this.entityName = name;
        this.actorSkills = actorSkills;

        //восстанавливаем несохраняемые поля через чертеж
        restoreData(EnemyStore.Instance.getObject(_id));
    }


    public void restoreData(EnemyBlueprint blueprint)
    {
        this.encounterDescription = blueprint.encounterDescription;
        this.endingDescription = blueprint.endingDescription;
    }



    public Enemy(EnemyBlueprint blueprint)
    {
        this._id = blueprint.Id;
        this.entityName = blueprint.EntityName;
        this.encounterDescription = blueprint.encounterDescription;
        this.endingDescription = blueprint.endingDescription;
        this.actorSkills = blueprint.skillsBlueprint.getClone();
    }
}
