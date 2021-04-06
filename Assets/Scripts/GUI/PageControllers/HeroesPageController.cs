using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesPageController : SelectorBoxList<Hero, ViewElement_Selectable<Hero>>, Page
{
    private List<Hero> towerHeroes;

    public void hide()
    {
        if (currentBoxObject != null) closeBox();
    }

    public void show()
    {
        towerHeroes = HeroDataManager.Instance.GetHeroesByState(Hero.HeroState.tower);
        updateGroup(towerHeroes);
    }

  

    protected override void onViewClicked(Id id)
    {
        var selectedHero = towerHeroes.Find(hero => hero.Id == id);
        if (selectedHero != null)
        {
            openBox(selectedHero);
        }
    }


}
