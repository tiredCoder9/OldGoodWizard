using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemViewStackable : ItemView
{

    public TextMeshProUGUI counter;

    public void setCount(int i)
    {
        count = i;
        if (i > 1) counter.gameObject.SetActive(true);
        else counter.gameObject.SetActive(false);
        counter.text = count.ToString();
    }
}
