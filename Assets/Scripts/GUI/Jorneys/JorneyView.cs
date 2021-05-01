using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JorneyView : ViewElement_Selectable<JorneyData>
{
    public TextMeshProUGUI heroName;
    public TextMeshProUGUI adventureName;
    public Image heroPortrait;

    public override void updateView(JorneyData data)
    {
        heroName.text = data.Hero.EntityName;
        adventureName.text = data.MainModule.Name;
        heroPortrait.sprite = data.Hero.getPortrait();

        id = data.Id;
    }
}
