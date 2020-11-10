using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Hero: Entity
{

    [SerializeField] [JsonProperty] private int nativeSanity = 1;
    [SerializeField] [JsonProperty] private string portraitSpriteName;

    //
    [SerializeField] 
    private Sprite portrait;
    //

    
    public Sprite getPortrait() { return portrait; }

    [JsonConstructor]
    public Hero(Id _id, string name, int power, int health, int sanity, string portraitSpriteName)
    {
        this._id = _id;
        this.entityName = name;
        this.nativeHealth = health;
        this.nativePower = power;
        this.nativeSanity = sanity;
        this.portraitSpriteName = portraitSpriteName;
        portrait = Resources.Load<Sprite>("Portraits/" + portraitSpriteName);
    }

}
