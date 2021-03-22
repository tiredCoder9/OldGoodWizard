using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrainable 
{
    LevelBehavior LevelBehavior { get; }
    void levelUp(long levelPoints, Dictionary<BaseAttribute.AttributeType, int> points);
}
