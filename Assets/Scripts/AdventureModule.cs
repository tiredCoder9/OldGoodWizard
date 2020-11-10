using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AdventureModule", menuName = "Adventure module")][System.Serializable]
public class AdventureModule : ScriptableObject, Identifyable
{
    public Id _id;
    public Id Id { get { return _id; } }

    public EnemyBlueprint[] enemies;
    public SpecialTrope[] specialTropes;
}
