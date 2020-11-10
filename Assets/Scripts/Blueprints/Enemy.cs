using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    //вычислить общую силу существа
    public int Difficult { get { return (nativeHealth + nativePower) / 2; } }

    [Newtonsoft.Json.JsonConstructor]
    public Enemy(Id _id, string name, int power, int health)
    {
        this._id = _id;
        this.entityName = name;
        this.nativeHealth = health;
        this.nativePower = power;
    }

    public Enemy(EnemyBlueprint blueprint)
    {
        this._id = blueprint.Id;
        this.entityName = blueprint.EntityName;
        this.nativeHealth = blueprint.NativeHealth;
        this.nativePower = blueprint.NativePower;
    }
}
