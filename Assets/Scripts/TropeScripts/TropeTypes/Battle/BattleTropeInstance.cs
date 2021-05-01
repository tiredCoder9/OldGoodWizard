using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class BattleTropeInstance : TropeInstance
{
    [JsonProperty] private BattleTropeData data;
    [JsonProperty] private BattleTropeBehaviour behaviour;

    [JsonConstructor]
    public BattleTropeInstance(BattleTropeBehaviour behaviour, BattleTropeData data, Id id)
    {
        this.behaviour = behaviour;
        this.data = data;
        this.id = id;
    }

    public override void begin(JorneyData jorney)
    {
        behaviour.begin(jorney, data);
    }

    public override bool ended(JorneyData jorney)
    {
        return behaviour.ended(jorney, data);
    }

    public override bool IsEnded => data.IsEnded;

    public override void InitializeBehaviours(JorneyData jorney)
    {
        List<Character> list = new List<Character>();
        list.AddRange(data.enemies);
        data.battle.SetValues(jorney.Hero, list);
    }

    public BattleTropeData getData()
    {
        return data;
    }
}
