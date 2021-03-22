using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu( fileName="Item", menuName="Items/BaseItem")]
public class Item : ScriptableObject, Identifyable
{
    [JsonProperty] [SerializeField] protected Id id;
    [JsonIgnore] public Sprite portrait;
    [JsonIgnore] public string itemName="_PLACEHOLDER_";
    [JsonIgnore] public string itemDescription= "_PLACEHOLDER_";
    public enum ItemType { active, inactive }

    [SerializeField][JsonIgnore] private ItemCategory itemCategory;
    [JsonIgnore] public ItemCategory ItemCategory { get{ return itemCategory; } }

    public Id Id { get { return id; } }


    [JsonConstructor]
    public Item(Id id)
    {
        this.id = id;
        restoreData();
    }

    protected virtual Item restoreData()
    {
        var originalItem = ItemsStore.Instance.getObject(id);
        itemName = originalItem.itemName;
        portrait = originalItem.portrait;
        itemCategory = originalItem.itemCategory;

        return originalItem;
    }

}


