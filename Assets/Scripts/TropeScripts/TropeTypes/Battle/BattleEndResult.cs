using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class BattleEndResult
{
    [JsonProperty] public int experienceGained;
    [JsonProperty] public ItemList loot;

    [JsonConstructor]
    public BattleEndResult(int experienceGained, ItemList loot)
    {
        this.experienceGained = experienceGained;
        this.loot = loot;
    }
}
