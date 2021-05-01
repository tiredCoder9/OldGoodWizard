using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Enemy : Character
{
    //вычислить общую силу существа
    [JsonIgnore] public int Difficult { get { return (MaxHealth*Power) / 2; } }
    [JsonIgnore] public int rewardExperience { get { return (int)(Difficult * 0.1); } }
    [JsonIgnore] public override ActorSkills ActorSkills { get { return actorSkills; } }

    [JsonIgnore] protected ItemList enemyLoot;

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
        this.enemyLoot = blueprint.enemyLoot;
    }



    public Enemy(EnemyBlueprint blueprint)
    {
        this._id = blueprint.Id;
        this.entityName = blueprint.EntityName;
        this.actorSkills = blueprint.skillsBlueprint.getClone();
        this.enemyLoot = blueprint.enemyLoot;
    }

    public ItemList GenerateLoot(int count)
    {
        ItemList loot = new ItemList();
        for(int i=0; i<count; i++)
        {
            loot.AddItem(enemyLoot.getListRaw().getRandomElement());
        }
        return loot;
    }
}
