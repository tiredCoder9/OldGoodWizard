using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


[CreateAssetMenu(menuName ="Items/EquippableItem")]
public class EquippableItem : Item, IEquippable, IBonusSource
{
    [JsonProperty] private bool isEquipped;
    [SerializeField] [JsonIgnore] private Bonus bonus;

    [JsonConstructor]
    public EquippableItem(Id id, bool isEquipped) : base(id)
    {
        this.isEquipped = isEquipped;
        this.restoreData();
    }

    public Bonus getBonus()
    {
        bonus.BonusSource = this;
        return bonus;
    }

    public BonusSourceType getBonusType()
    {
        return BonusSourceType.Item;
    }

    public Id getSourceId()
    {
        return id;
    }

    public Sprite getIcon()
    {
        return portrait;
    }

    public bool IsEquipped()
    {
        return isEquipped;
    }

    protected override Item restoreData()
    {
        var originalItem = base.restoreData();
        if(originalItem is IBonusSource)
        {
            this.bonus = ((IBonusSource)originalItem).getBonus();
            bonus.BonusSource = this;
            Debug.Log("Item " + itemName + " has bonus");
        }
        Debug.Log("overwritten method called!");
        return originalItem;
    }

    public void Equip()
    {
        isEquipped = true;
    }
}

