using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemGrid : ViewListGroup<Item, ItemViewStackable>
{
    private ItemList itemList;

    public void UpdateGrid(ItemList list, ItemCategory category)
    {
        itemList = list;
        if (itemList != null)
        {
            if(category==ItemCategory.Miscellaneous)
                updateGroup(itemList.getRawDistinct());
            else
                updateGroup(itemList.getRawDistinct(category));
        }
        
    }



    protected override void handleElement(Item data, ItemViewStackable viewElement)
    {
        base.handleElement(data, viewElement);
        viewElement.setCount(itemList.getCount(data));
    }



}
