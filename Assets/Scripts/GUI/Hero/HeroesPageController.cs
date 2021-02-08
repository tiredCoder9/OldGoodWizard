using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesPageController : ViewListGroup<Hero, ViewElement<Hero>>, Page
{
    public void hide()
    {
       
    }

    public void show()
    {
        List<Hero> heroes = HeroDataManager.Instance.GetHeroesByState(Hero.HeroState.tower);
        updateGroup(heroes);
    }


}
