using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] private ItemList craftItems;
    
    [SerializeField] private ItemList resultItems;

    [SerializeField] private float craftProcessTime;

    public float CraftTime { get { return craftProcessTime; } }

    public ItemList CraftItems { get { return craftItems; } }

    public ItemList ResultItems { get { return resultItems; } }

    public virtual bool IsCraftable()
    {
        return true;
    }

    public bool IsRequiresComponents(ItemList itemList)
    {
        return itemList == craftItems;
    }

}
