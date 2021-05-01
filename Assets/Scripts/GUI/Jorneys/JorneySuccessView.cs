using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JorneySuccessView : JorneyResultView
{
    [SerializeField]
    TextMeshProUGUI heroName;
    [SerializeField]
    ItemGrid itemGrid;

    public override void SetValue(JorneyData data)
    {
        heroName.text = data.Hero.EntityName + "�������� � �����";
        itemGrid.UpdateGrid(data.Inventory, ItemCategory.Miscellaneous);
    }

}
