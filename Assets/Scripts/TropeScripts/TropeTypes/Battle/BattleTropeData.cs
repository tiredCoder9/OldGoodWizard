using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class BattleTropeData : TropeData
{
    //оригинальный обьект монстра, используется для клонирования
    [JsonProperty] private Id refEnemyID;
    [JsonProperty] public Enemy enemy;

    [JsonIgnore] private EnemyBlueprint refEnemy { get { return EnemyStore.Instance.getObject(refEnemyID); } }

    [JsonConstructor]
    public BattleTropeData(Id refEnemyID, Enemy enemy)
    {
        this.refEnemyID = refEnemyID;
        this.enemy = enemy;
    }



}

