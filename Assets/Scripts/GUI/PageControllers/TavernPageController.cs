using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernPageController : ViewListGroup<Hero, TavernHeroView>, Page
{
    public GameObject tavernHeroBoxObject;
    public HeroBoxGroup tavernHeroBox;

    public GameObject tavernHeroBoxPrefab;
    public Transform boxTransformParent;

    private List<Hero> TavernHeroes;

    private Hero lastSelectedHero;

    public void Start()
    {
        
        EventSystem.Instance.AddEventListener<GUIEvent_hireHero>(OnHeroWasHired);
    }



    public void updatePage()
    {
        if (tavernHeroBox == null) createBox();
        TavernHeroes = HeroDataManager.Instance.GetHeroesByState(Hero.HeroState.tavern);
        updateGroup(TavernHeroes);
    }

    private void createBox()
    {
        tavernHeroBoxObject = Instantiate(tavernHeroBoxPrefab, boxTransformParent);
        tavernHeroBox = tavernHeroBoxObject.GetComponent<HeroBoxGroup>();
        tavernHeroBox.OnBoxClosed.AddListener(closeHeroBox);

    }

    protected override void createView()
    {
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        var view = viewObject.GetComponent<TavernHeroView>();
        view.OnHireButtonClickEvent.AddListener(OnHireButtonClick);
        view.OnClickEvent.AddListener(OnSelectClick);
        views.Add(view);
    }


    private void OnHeroWasHired(GUIEvent_hireHero e)
    {
        if(lastSelectedHero!=null && tavernHeroBox.IsOpen)
        closeHeroBox(lastSelectedHero);
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

    private void OnSelectClick(Id _id)
    {
        var selectedHero = TavernHeroes.Find(h => h.Id == _id);
        if (selectedHero != null)
        {
            if (selectedHero.State == Hero.HeroState.tavern)
            {
                OpenHeroBox(selectedHero);
            }
        }
    }

    public void OpenHeroBox(Hero hero)
    {
        lastSelectedHero = hero;
        tavernHeroBoxObject.SetActive(true);
        tavernHeroBox.OnOpen(hero);
    }

    public void closeHeroBox(Hero lastHero)
    {

        tavernHeroBox.OnClose(lastHero);
        tavernHeroBoxObject.SetActive(false);
        lastSelectedHero = null;
    }
}
