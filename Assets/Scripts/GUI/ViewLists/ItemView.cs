using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : ViewElement_Selectable<Item>
{

    public int count = 1;
    public Image itemIcon;
    private Item item;

    public override void updateView(Item data)
    {
        itemIcon.sprite = data.portrait;
        item = data;
    }

}
