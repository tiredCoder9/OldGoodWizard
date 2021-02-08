using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Health : ResourceAttribute
{
    public Health(int baseValue, int baseMultiplier = 0) : base(baseValue, baseMultiplier)
    {
        type = BaseAttribute.AttributeType.health;
    }

    [JsonConstructor]
    public Health(int baseValue, bool IsRecalculated, int currentValue, int finalValue, int baseMultiplier = 0) : base(baseValue, IsRecalculated, currentValue, finalValue, baseMultiplier)
    {
        type = BaseAttribute.AttributeType.health;
    }
}
