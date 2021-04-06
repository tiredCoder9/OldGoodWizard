using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

[System.Serializable]
public class ItemList
{
    [JsonProperty] [SerializeField] protected List<Item> items;

    public ItemList()
    {
        items = new List<Item>();
    }

    [JsonConstructor]
    public ItemList(List<Item> items)
    {
        this.items = items;
    }

    public virtual void AddItem(Item item)
    {
        items.Add(item);
    }

    public virtual void RemoveItem(Item item)
    {
        var foundedItem = items.Find(i => i.Id == item.Id);
        if (foundedItem != null) items.Remove(foundedItem);
    }

    public virtual List<Item> getListRaw()
    {
        return items;
    }

    public virtual bool IsContainsItem(Item item)
    {
        return items.Any(i => i.Id == item.Id);
    }

    public virtual bool IsContainsItemList(ItemList list)
    {
        var contentList = list.getListRaw();

        foreach(var item in contentList.Distinct())
        {
            if (items.Count(i => i.Id == item.Id) < contentList.Count(j => j.Id == item.Id)) return false;
        }
        return true;
    }

    public virtual void AddList(ItemList list)
    {
        foreach(var i in list.getListRaw())
        {
            items.Add(i);
        }
    }

    public virtual int getCount(Item item)
    {
        return items.Count(i => i.Id == item.Id);
    }

    public virtual int getCount()
    {
        return items.Count;
    }

    public virtual List<Item> getRawDistinct()
    {
        List<Item> distinctList = new List<Item>();
        HashSet<Id> uniqLookup = new HashSet<Id>();

        foreach(var item in items)
        {
            if (!uniqLookup.Contains(item.Id))
            {
                uniqLookup.Add(item.Id);
                distinctList.Add(item);
            }
        }

        return distinctList;
    }

    public virtual List<Item> getRawDistinct(ItemCategory category)
    {
        List<Item> distinctList = new List<Item>();
        HashSet<Id> uniqLookup = new HashSet<Id>();

        foreach (var item in items)
        {
            if (!uniqLookup.Contains(item.Id) && item.ItemCategory == category)
            {
                uniqLookup.Add(item.Id);
                distinctList.Add(item);
            }
        }

        return distinctList;
    }


    

    public static bool operator ==(ItemList a, ItemList b)
    {
        if ((IsNull(a) ^ IsNull(b))) return false;
        if (IsNull(a)) return true;

        
        if (a.items.Count != b.items.Count) return false;
        if (a.IsContainsItemList(b)) return true;

        return false;
    }

    public static bool operator !=(ItemList a, ItemList b)
    {
        if ((IsNull(a)^IsNull(b))) return true;
        if (IsNull(a)) return false;

        if (a.items.Count != b.items.Count) return true;
        if (!a.IsContainsItemList(b)) return true;

        return false;
    }

    public static bool IsNull(ItemList a)
    {
        return ReferenceEquals(a, null);
    }



}
