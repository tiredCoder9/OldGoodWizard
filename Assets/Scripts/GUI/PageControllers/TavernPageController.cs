using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernPageController : SelectorBoxList<Hero, TavernHeroView>, Page
{

    private List<Hero> TavernHeroes;

    private Hero lastSelectedHero;

    public void Start()
    {
        EventSystem.Instance.AddEventListener<GUIEvent_hireHero>(OnHeroWasHired);
    }



    public void updatePage()
    {
        TavernHeroes = HeroDataManager.Instance.GetHeroesByState(Hero.HeroState.tavern);
        updateGroup(TavernHeroes);
    }


    protected override void createView()
    {
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        var view = viewObject.GetComponent<TavernHeroView>();
        view.OnHireButtonClickEvent.AddListener(OnHireButtonClick);
        view.OnClickEvent.AddListener(onViewClicked);
        views.Add(view);
    }


    private void OnHeroWasHired(GUIEvent_hireHero e)
    {
        if (lastSelectedHero != null && currentBoxObject != null)
            closeBox();
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
        if (currentBoxObject != null) closeBox();
    }


    protected override void openBox(Hero data)
    {
        lastSelectedHero = data;
        base.openBox(data);
    }


    protected override void closeBox()
    {
        base.closeBox();
        lastSelectedHero = null;
    }


    protected override void onViewClicked(Id id)
    {
        var selectedHero = TavernHeroes.Find(h => h.Id == id);
        if (selectedHero != null)
        {
            if (selectedHero.State == Hero.HeroState.tavern)
            {
                openBox(selectedHero);
            }
        }
    }
}
