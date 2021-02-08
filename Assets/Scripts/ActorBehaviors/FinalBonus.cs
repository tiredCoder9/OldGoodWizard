using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class FinalBonus : BaseAttribute
{
    [JsonConstructor]
    public FinalBonus(int baseValue = 0, int baseMultiplier = 0) : base(baseValue, false, baseMultiplier) { }
}
