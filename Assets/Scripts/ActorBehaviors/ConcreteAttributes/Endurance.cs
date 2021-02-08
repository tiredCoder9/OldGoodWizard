using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class Endurance : SkillAttribute
{

    public Endurance(int baseValue, int maxValue = 100, int baseMultiplier = 0) : base(baseValue, maxValue, baseMultiplier)
    {
        type = AttributeType.endurance;
    }

    [JsonConstructor]
    public Endurance(int baseValue, int maxValue, int baseMultiplier, int finalValue, bool IsRecalculated) : base(baseValue, maxValue, baseMultiplier, finalValue, IsRecalculated)
    {
        type = AttributeType.endurance;
    }
}
