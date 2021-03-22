using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBonusSource
{
    Id getSourceId();
    Bonus getBonus();
    BonusSourceType getBonusType();
}
