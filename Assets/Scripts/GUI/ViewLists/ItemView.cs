using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemView : ViewElement_Selectable<Item>
{
    public int count = 1;
    public Image itemIcon;
    public TextMeshProUGUI counter;
    public override void updateView(Item data)
    {
        itemIcon.sprite = data.portrait;
    }

    public void setCount(int i)
    {
        count = i;
        if (i > 1) counter.gameObject.SetActive(true);
        else counter.gameObject.SetActive(false);
        counter.text = count.ToString();
    }
}
