using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBoxElement : BoxElement<Hero>
{
    public GameObject ItemViewPrefab;

    public List<ItemView> itemViews;

    public Transform viewsParent;

    public void Awake()
    {
        itemViews = new List<ItemView>();
    }

    public override void OnClose(Hero data)
    {
        foreach (var it in itemViews)
        {
            Destroy(it);
        }
    }

    public override void OnOpen(Hero data)
    {
        UpdateEquipment(data.Equipment);
    }

    public void UpdateEquipment(EquipmentItemList equipmentItemList)
    {


        var items = equipmentItemList.getListRaw();

        foreach(var it in items)
        {
            GameObject obj = Instantiate(ItemViewPrefab, viewsParent);
            ItemView view = obj.GetComponent<ItemView>();
            view.updateView(it);
            itemViews.Add(view);
        }


    }
}
