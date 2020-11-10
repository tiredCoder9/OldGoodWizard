using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AdventureTextPatternStore : DataStore<AdventureTextPatternStore, AdventureTextPattern>
{

    public AdventureTextPattern getRandomTextByType(AdventureTextPattern.DescriptionType _type)
    {
        var selected = collection.Where(text => text.type == _type);
        return selected.ElementAt(Random.Range(0, selected.Count()));
    }
    
}
