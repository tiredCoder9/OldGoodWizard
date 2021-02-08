using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Mind : ResourceAttribute
{
    public Mind(int baseValue, int baseMultiplier = 0) : base(baseValue, baseMultiplier)
    {
        type = AttributeType.mind;
    }

    [JsonConstructor]
    public Mind(int baseValue, bool IsRecalculated, int currentValue, int finalValue, int baseMultiplier = 0) : base(baseValue, IsRecalculated, currentValue, finalValue, baseMultiplier)
    {
        type = AttributeType.mind;
    }
}
