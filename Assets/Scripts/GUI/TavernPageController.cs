using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernPageController : ViewListGroup<Hero, ViewElement_Selectable<Hero>>, Page
{
    public HeroGenerator generator;


    public void updatePage()
    {
        List<Hero> tavernHeroes = HeroDataManager.Instance.GetHeroesByState(Hero.HeroState.tavern);
        updateGroup(tavernHeroes);
    }

    protected override void createView()
    {
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        var view = viewObject.GetComponent<ViewElement_Selectable<Hero>>();
        view.OnClickEvent.AddListener(OnHireButtonClick);
        views.Add(view);
    }

    private void OnHireButtonClick(Id id)
    {
        EventSystem.Instance.Raise(new GUIEvent_hireHero(id));
    }

    private void OnHeroesStateChanged(Event_HeroStateChanged e)
    {
        updatePage();
    }

    public void show()
    {
        updatePage();
        EventSystem.Instance.AddEventListener<Event_HeroStateChanged>(OnHeroesStateChanged);
    }

    public void hide()
    {
        EventSystem.Instance.RemoveEventListener<Event_HeroStateChanged>(OnHeroesStateChanged);
    }
}
