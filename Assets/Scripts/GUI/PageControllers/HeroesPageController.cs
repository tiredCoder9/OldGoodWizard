using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesPageController : ViewListGroup<Hero, ViewElement_Selectable<Hero>>, Page
{

   
    
    public GameObject HeroBoxPrefab;
    public Transform BoxParentObject;

    private List<Hero> towerHeroes;
    private Hero lastData;
    private HeroBoxGroup heroBox;
    private GameObject heroBoxObject;

    public void hide()
    {
       
    }

    public void show()
    {
        towerHeroes = HeroDataManager.Instance.GetHeroesByState(Hero.HeroState.tower);
        createBox();
        updateGroup(towerHeroes);
    }

    public void createBox()
    {
        if(heroBox == null)
        {
            heroBoxObject = Instantiate(HeroBoxPrefab, BoxParentObject);
            heroBox = heroBoxObject.GetComponent<HeroBoxGroup>();
            heroBox.OnBoxClosed.AddListener(OnBoxClose);
        }
    }



    protected override void createView()
    {
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        var view = viewObject.GetComponent<ViewElement_Selectable<Hero>>();
        view.OnClickEvent.AddListener(OnViewClick);
        views.Add(view);
    }

    public void OnViewClick(Id id)
    {
        var selectedHero = towerHeroes.Find(hero => hero.Id == id);
        if (selectedHero != null)
        {
            OpenBox(selectedHero);
        }
    }

    public void OnBoxClose(Hero hero)
    {
        if (hero != null)
        {
            if (heroBox != null)
            {
                closeBox(hero);
            }
        }
    }

    public void OpenBox(Hero hero)
    {
        if (!heroBox.IsOpen)
        {
            heroBox.OnOpen(hero);
            heroBoxObject.SetActive(true);
        }
    }

    public void closeBox(Hero hero)
    {
        if (heroBox.IsOpen)
        {
            heroBox.OnClose(hero);
            heroBoxObject.SetActive(false);
        }
    }

}
