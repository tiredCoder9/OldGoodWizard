using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesPageController : MonoBehaviour
{
    public List<Hero> heroes;
    public List<HeroView> views;

    public GameObject heroViewPrefab;

    private void Start()
    {
        updateHeroesPage();
    }


    public void updateHeroesPage()
    {
        if (views == null) views = new List<HeroView>();

        heroes = HeroDataManager.Instance.getObjects();

        if (heroes.Count != views.Count)
        {
            createViews(heroes);
        }

        for(int i=0; i<heroes.Count; i++)
        {

            views[i].draw(heroes[i]);
        }

    }


    public void createViews(List<Hero> listHeroes)
    {
        if (listHeroes.Count < views.Count)
        {
            for (int i = 0; i < views.Count - listHeroes.Count; i++)
            {
                var view = views[i];
                views.RemoveAt(i);
                Destroy(view.gameObject);
            }
        }
        else if (listHeroes.Count > views.Count)
        {
            for (int i = listHeroes.Count - views.Count; i > 0 ; i--)
            {
                GameObject viewObject = Instantiate(heroViewPrefab, transform);
                HeroView view = viewObject.GetComponent<HeroView>();
                views.Add(view);
            }
        }


    }

}
