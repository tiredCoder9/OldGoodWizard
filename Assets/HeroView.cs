using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroView : ViewElement_Selectable<Hero>
{
    public Image portrait;
    public Sprite defaultPortrait;
    public TextMeshProUGUI heroName;

    public override void updateView(Hero data)
    {
        id = data.Id;
        portrait.sprite = defaultPortrait;
        if (data.getPortrait() != null)
        {
            portrait.sprite = data.getPortrait();
        }
        heroName.text = data.EntityName;
    }
}
