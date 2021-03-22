using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroElement : BoxElement<Hero>
{
    public Image heroPortrait;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI health;
    public TextMeshProUGUI mind;

    public TextMeshProUGUI heroName;
    public TextMeshProUGUI heroClass;

    public override void OnClose(Hero data)
    {
        
    }

    public override void OnOpen(Hero data)
    {

        heroPortrait.sprite = data.getPortrait();
        attack.text = data.Power.ToString();
        health.text = data.MaxHealth.ToString();
        mind.text = data.MaxMind.ToString();

        heroClass.text = data.ClassName;
        heroName.text = data.EntityName;

    }
}
