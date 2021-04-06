using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class Wisdom : SkillAttribute
{

    public Wisdom(int baseValue, int maxValue = 100, int baseMultiplier = 0) : base(baseValue, maxValue, baseMultiplier)
    {
        type = AttributeType.wisdom;
    }

    [JsonConstructor]
    public Wisdom(int baseValue, int maxValue, int baseMultiplier, bool IsRecalculated) : base(baseValue, maxValue, baseMultiplier, IsRecalculated)
    {
        type = AttributeType.wisdom;
    }
}
