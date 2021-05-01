using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPageController : MonoBehaviour, Page
{
    public ItemGrid grid;
    public PlayerInventoryList inventory;

    public ItemCategory category = ItemCategory.Miscellaneous;

    public ItemSortTab[] tabs;

    [SerializeField] private Sprite activeBg;
    [SerializeField] private Sprite inctiveBg;

    private bool IsStartSeleted;

    public void hide()
    {
        
    }

    public void show()
    {   
        if (!IsStartSeleted)
        {
            IsStartSeleted = true;
            tabs[0].Select();
            return;
        }
        grid.UpdateGrid(inventory.getValue(), category);
    }

    private void UpdatePage()
    {
        foreach(var tab in tabs)
        {
            if (tab.GetCategory() == category) tab.background.sprite = activeBg;
            else tab.background.sprite = inctiveBg;
        }
        grid.UpdateGrid(inventory.getValue(), category);
    }

    public void SelectCategory(ItemCategory itemCategory)
    {
        category = itemCategory;
        UpdatePage();
    }

    
}
