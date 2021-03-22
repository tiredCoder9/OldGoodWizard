using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEvent_ForgeItemCraft : Event_GameEvent
{
    public ItemList craftItems;

    public GUIEvent_ForgeItemCraft(ItemList craftItems)
    {
        this.craftItems = craftItems;
    }
}
