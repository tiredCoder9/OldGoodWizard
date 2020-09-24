using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AdventureModule", menuName = "Adventure module")]
public class AdventureModule : ScriptableObject
{
    public BattleTrope[] battleTropes;
    public SpecialTrope[] specialTropes;

    //TODO: добавить небоевые события

    
}
