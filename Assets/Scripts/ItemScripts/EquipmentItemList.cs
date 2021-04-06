using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class EquipmentItemList : ItemList
{
    
    private int equipmentSlotsCount=1;

    public static int MAX_EQUIPMENT_SLOTS=3;

    [JsonConstructor]
    public EquipmentItemList(List<Item> items, int equipmentSlotsCount) : base (items)
    {
        this.equipmentSlotsCount = equipmentSlotsCount;
    }

    public EquipmentItemList(int equipmentSlotsCount)
    {
        this.equipmentSlotsCount = equipmentSlotsCount;
        this.items = new List<Item>();
    }

    public override void AddItem(Item item)
    {
        if (items.Count+1 <= equipmentSlotsCount)
        {
            base.AddItem(item);
        }   
    }

    public override void AddList(ItemList list)
    {
        if(items.Count+list.getCount()<=equipmentSlotsCount)
        base.AddList(list);
    }

    public static int checkEquipmentLimit(int slotsCount)
    {
        if (slotsCount > MAX_EQUIPMENT_SLOTS)
        {
            return MAX_EQUIPMENT_SLOTS;
        }
        return slotsCount;
    }


}
