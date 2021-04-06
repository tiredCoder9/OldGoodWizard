using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class TavernHeroView : ViewElement_Selectable<Hero>
{
    public Image portrait;
    public Sprite defaultPortaitSprite;
    public TextMeshProUGUI heroName;
    public TextMeshProUGUI price;

    public TextMeshProUGUI power;
    public TextMeshProUGUI health;
    public TextMeshProUGUI sanity;


    public UnityEvent<Id> OnHireButtonClickEvent;

    public override void updateView(Hero hero)
    {
        portrait.sprite = defaultPortaitSprite;
        if (hero.getPortrait() != null)
        {
            portrait.sprite = hero.getPortrait();
        }
        price.text = hero.getPrice().ToString();
        heroName.text = hero.EntityName;

        power.text = hero.Power.ToString();
        health.text = hero.CurrentHealth.ToString();
        sanity.text = hero.CurrentMind.ToString();
        id = hero.Id;
    }


    public void OnHireButtonClick()
    {
        if (OnHireButtonClickEvent != null)
            OnHireButtonClickEvent.Invoke(id);
    }

    public void OnSelectClick()
    {
        print("here");
        if (OnClickEvent != null)
            OnClickEvent.Invoke(id);
    }
}
