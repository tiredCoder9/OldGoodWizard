using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroView : MonoBehaviour
{
    private Hero hero;
    public Image portrait;
    public Sprite defaultPortaitSprite;
    public TextMeshProUGUI heroName;


    public void draw(Hero hero)
    {
        portrait.sprite = defaultPortaitSprite;
        if (hero.getPortrait() != null)
        {
            portrait.sprite = hero.getPortrait();
        }
        heroName.text = hero.EntityName;
    }
}
