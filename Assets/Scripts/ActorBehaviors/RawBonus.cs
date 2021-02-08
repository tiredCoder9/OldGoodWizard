using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class RawBonus : BaseAttribute
{
    [JsonConstructor]
    public RawBonus(int baseValue=0, int baseMultiplier = 0): base (baseValue, false, baseMultiplier) { }
}
