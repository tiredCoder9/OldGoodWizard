using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectedAdventureBoxElement : BoxElement<AdventureModule>
{
    public TextMeshProUGUI adventureName;
    public Id selectedAdventureId;

    public override void OnClose(AdventureModule data)
    {
        selectedAdventureId = Id.empty;
    }

    public override void OnOpen(AdventureModule data)
    {
        selectedAdventureId = data.Id;
        adventureName.text = data.Name;
    }
}
