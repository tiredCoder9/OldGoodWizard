using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class BattleTropeData : TropeData
{
    //оригинальный обьект монстра, используется для клонирования
    [JsonProperty] public List<Enemy> enemies;
    [JsonProperty] public Battle battle;
    [JsonProperty] public bool isBattleEnded;
    [JsonProperty] public double battleEndTime;
    [JsonProperty] public BattleEndResult battleResult;
    [JsonProperty] private string encounterDescription;
    [JsonProperty] private string endingDescription;

    [JsonIgnore] public System.Action<BattleEndResult> OnBattleEnded;

    public string EncounterDescription { get => encounterDescription; }
    public string EndingDescription { get => endingDescription; }

    [JsonConstructor]
    public BattleTropeData(List<Enemy> enemy, Battle battle, string encounterDescription, string endingDescription,  bool isEnded)
    {
        this.enemies = enemy;
        this.battle = battle;
        this.isEnded = isEnded;
        this.encounterDescription = encounterDescription;
        this.endingDescription = endingDescription;
    }

    public List<Enemy> getEnemies()
    {
        return enemies;
    }

    

}

