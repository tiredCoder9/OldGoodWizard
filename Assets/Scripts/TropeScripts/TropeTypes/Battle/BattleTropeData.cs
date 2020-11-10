using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class BattleTropeData : TropeData
{
    //оригинальный обьект монстра, используется для клонирования
    [JsonProperty] private Id refEnemyID;
    [JsonProperty] private Id startDescriptionID;
    [JsonProperty] private Id endDescriptionID;
    [JsonProperty] private string serialized_enemy;
    [JsonProperty] public Enemy enemy;

    [JsonIgnore] private EnemyBlueprint refEnemy { get { return EnemyStore.Instance.getObject(refEnemyID); } }
    [JsonIgnore] public AdventureTextPattern EncounterDescr { get { return AdventureTextPatternStore.Instance.getObject(startDescriptionID); } }
    [JsonIgnore] public AdventureTextPattern EndingDescr { get { return AdventureTextPatternStore.Instance.getObject(endDescriptionID); } }



    [JsonConstructor]
    public BattleTropeData(Id refEnemyID, Id startDescription, Id endDescription)
    {
        this.refEnemyID = refEnemyID;
        this.enemy = refEnemy.getClone();
        this.startDescriptionID = startDescription;
        this.endDescriptionID = endDescription;
    }


    public override void deserialize()
    {
        ////создаем копию обьекта (т.к изначально enemy = null)
        //enemy = ScriptableObject.Instantiate(refEnemy);
        ////после чего перезаписываем в него сохраненные значения
        //JsonUtility.FromJsonOverwrite(serialized_enemy, enemy);

    }

    public override void serialize()
    {
        //serialized_enemy = JsonConvert.SerializeObject(enemy);
    }
}

