using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HeroControlBoxElement: BoxElement<JorneyData>
{

    [Header("UI elements")]
    public Image Portrait;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI health;
    public TextMeshProUGUI sanity;



    public override void OnOpen(JorneyData data)
    {
        updateHero(data.Hero);
    }

    public override void OnClose(JorneyData data)
    {
        
    }



    private void updateHero(Hero hero)
    {
        Name.text = hero.EntityName;
        Portrait.sprite = hero.getPortrait();
        health.text = hero.CurrentHealth.ToString();
        sanity.text = hero.CurrentMind.ToString();
    }



}
