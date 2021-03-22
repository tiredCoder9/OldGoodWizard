using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Bonus : BaseAttribute
{
    private IBonusSource bonusSource;
    [SerializeField] private BonusType bonusType;

    public IBonusSource BonusSource { get => bonusSource; set => bonusSource = value; }
    public BonusType Type { get { return bonusType; } }

    [JsonConstructor]
    public Bonus(int baseValue = 0, int baseMultiplier = 0) : base(baseValue, false, baseMultiplier) { } 
}
