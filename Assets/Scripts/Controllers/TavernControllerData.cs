using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TavernControllerData : PersistentControllerData
{
    public long lastHeroesSetChangeDate = 0;

    public TavernControllerData()
    {
        _id = new Id(typeof(TavernController).Name);
    }
}
