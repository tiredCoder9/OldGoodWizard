using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ForgeCraftController : MonoBehaviour
{
    public PlayerInventoryList inventoryList;

    public List<Recipe> availableRecipes;

    private void Awake()
    {
        EventSystem.Instance.AddEventListener<GUIEvent_ForgeItemCraft>(OnForgeCraft);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnForgeCraft(GUIEvent_ForgeItemCraft e)
    {
        Recipe recipe = recipeExists(e.craftItems);

        if (recipe!=null)
        {
            if (inventoryList.getValue().IsContainsItemList(e.craftItems))
            {
                foreach (var item in e.craftItems.getListRaw())
                {
                    inventoryList.getValue().RemoveItem(item);
                    print("item used ->" + item.name);
                }

                foreach (var item in recipe.ResultItems.getListRaw())
                {
                    inventoryList.getValue().AddItem(item);
                    print("item crafted ->" + item.name);
                }
                inventoryList.setDirty(true);

                print("Item crafted!");
            }
            else
            {
                print("Not enough items to craft!");
            }
        }
        else
        {
            print("Recipe doesnt exists!");
        }


    }


    public Recipe recipeExists(ItemList items)
    {
        foreach(var rec in availableRecipes)
        {
            if (rec.IsRequiresComponents(items)) return rec;
        }
        return null;
    }
}
